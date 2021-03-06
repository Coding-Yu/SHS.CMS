﻿using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Repository.Interfaces;
using SHS.Service.Interfaces;
using SHS.Service.PermissionService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHS.Service.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<RolePermission> _rolePermissionRepository;
        private readonly ILogger<PermissionService> _logger;
        public PermissionService(IRepository<Permission> permissionRepository, ILogger<PermissionService> logger, IRepository<RolePermission> rolePermissionRepository)
        {
            _logger = logger;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }
        public async Task<Result> Add(Permission permission)
        {
            try
            {
                if (permission != null)
                {
                    await _permissionRepository.AddByAsync(permission);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("权限添加异常：" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<Result> Delete(string id, string userId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(userId))
                {
                    var permission = await _permissionRepository.GetByAsync(id);
                    if (permission != null)
                    {
                        permission.IsDel = 1;
                        permission.DeleteDate = DateTime.Now;
                        permission.DeleteUserId = Guid.Parse(userId);
                        await _permissionRepository.RemoveByAsync(permission);
                    }
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("权限删除异常：" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<Permission> Get(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return await _permissionRepository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("权限获取异常：" + ex.ToString());
                return null;
            }
        }

        public async Task<PagedResultDto<Permission>> GetAll(QueryPermissionFilter filter)
        {
            var result = new PagedResultDto<Permission>();
            try
            {
                var query = await _permissionRepository.GetAllByAsync();
                query = query.Where(x => x.IsDel == 0);
                if (!string.IsNullOrWhiteSpace(filter.name))
                {
                    query = query.Where(x => x.Name == filter.name);
                }
                result.TotalCount = query.Count();
                result.Items = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("获取异常" + ex.ToString());
            }
            return result;
        }

        public async Task<Result> Update(Permission permission)
        {
            try
            {
                if (permission != null)
                {
                    permission.UpdateDate = DateTime.Now;
                    await _permissionRepository.UpdateByAsync(permission);
                    Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("权限更新异常：" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<List<Permission>> GetPermissionByRoleId(string roleId)
        {
            var result = new List<Permission>();
            if (!string.IsNullOrWhiteSpace(roleId))
            {
                var rolePermissionQuery = await _rolePermissionRepository.GetAllByAsync();
                var rolePermissionList = rolePermissionQuery.Where(x => x.RoleId == Guid.Parse(roleId)).ToList();
                var permissionQuery = await _permissionRepository.GetAllByAsync();
                var permissionList = permissionQuery.Where(x => x.IsDel == 0).ToList();
                var s = from p in permissionList
                        join rolep in rolePermissionList
                        on p.ID equals rolep.PermissionId
                        select new Permission
                        {
                            CreateDate = p.CreateDate,
                            CreateUserId = p.CreateUserId,
                            DeleteDate = p.DeleteDate,
                            DeleteUserId = p.DeleteUserId,
                            ID = p.ID,
                            IsDel = p.IsDel,
                            Name = p.Name,
                            Path = p.Path,
                            Remarks = p.Remarks,
                            Sort = p.Sort,
                            UpdateDate = p.UpdateDate,
                            UpdateUserId = p.UpdateUserId
                        };
                result = s.ToList();
            }
            return result;
        }
    }
}
