﻿using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Domain.Repository.Interfaces;
using SHS.Infra.Data.Users;
using SHS.Service.Interfaces;
using SHS.Service.RoleService.Dto;
using SHS.Service.UsersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHS.Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<RolePermission> _rolePermissionRepository;
        private readonly ILogger<RoleService> _logger;
        public RoleService(IRepository<Role> roleRepository,
            ILogger<RoleService> logger,
            IUserService userService,
            IRepository<User> userRepository,
            IRepository<RolePermission> rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _userRepository = userRepository;
            _logger = logger;
            _roleRepository = roleRepository;
        }
        public async Task<Result> Add(Role role)
        {
            try
            {
                if (role != null)
                {
                    await _roleRepository.AddByAsync(role);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("角色添加异常");
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<Result> Delete(string id)
        {
            try
            {
                
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    var entity = await _roleRepository.GetByAsync(id);
                    //在删除角色时应该是直接赋予该角色下所有用户为默认角色，且默认角色不可删除
                    if (entity != null && entity.IsDefault == false)
                    {
                        //将该角色下得用户全部转为默认角色
                        var users = _userRepository.GetAll().Where(x => x.RoleID ==Guid.Parse(id)).ToList();//获取所有该角色得用户
                        var defalutRole = _roleRepository.GetAll().FirstOrDefault(x => x.IsDefault == true);//获取默认角色
                        foreach (var user in users)
                        {
                            user.RoleID = defalutRole.ID;
                            await _userRepository.UpdateByAsync(user);
                        }
                        //删除角色权限关联
                        var rolePermission = _rolePermissionRepository.GetAll().Where(x => x.RoleId ==Guid.Parse(id)).ToList();
                        foreach (var rolePermissionItem in rolePermission)
                        {
                            _rolePermissionRepository.Remove(rolePermissionItem);
                        }
                        await _roleRepository.RemoveByAsync(entity);
                        return Result.Success(200);
                    }
                    else
                    {
                        return Result.Fail(503, "默认角色不能删除");
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("角色删除异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<Role> Get(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return await _roleRepository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("角色查询异常" + ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Role>> GetAll(QueryRoleFilter filter)
        {
            var result = new List<Role>();
            try
            {
                var query = await _roleRepository.GetAllByAsync();
                if (!string.IsNullOrWhiteSpace(filter.name))
                {
                    query = query.Where(x => x.Name == filter.name);
                }
                result = query.OrderByDescending(x => x.CreateDate).Skip(filter.PageSize * (filter.PageNum - 1)).Take(filter.PageSize).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("获取异常" + ex.ToString());
            }
            return result;
        }

        public async Task<Result> RoleGivePermission(string roleid, List<string> permissionIds)
        {
            try
            {
                if (!string.IsNullOrEmpty(roleid.ToString()) && permissionIds.Count > 0)
                {
                    foreach (var pid in permissionIds)
                    {
                        //TODO 这里需要校验权限是否存在
                        await _rolePermissionRepository.AddByAsync(new RolePermission()
                        {
                            PermissionId =Guid.Parse(pid),
                            RoleId =Guid.Parse( roleid),
                        });
                    }
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("角色赋予权限异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<Result> Update(Role role)
        {
            try
            {
                if (role != null)
                {
                    var defaultRole = _roleRepository.GetAll().FirstOrDefault(x => x.IsDefault == true);
                    if (role.IsDefault == true && defaultRole != null)
                    {
                        _logger.LogError("{0}:,{1},更新失败，已存在默认角色不能直接修改默认角色", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "RoleServiceUpdateRole");
                        return Result.Fail(500, "已存在默认角色不能直接修改默认角色");
                    }
                    else
                    {
                        await _roleRepository.UpdateByAsync(role);
                        return Result.Success(200);
                    }
                }
                _logger.LogError("{0}:,{1},更新失败", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), "RoleServiceUpdateRole");
                return Result.Fail(500);
            }
            catch (Exception ex)
            {

                _logger.LogError("角色更新异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }
    }
}