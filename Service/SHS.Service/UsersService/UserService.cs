﻿using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Roles;
using SHS.Domain.Repository.Interfaces;
using SHS.Infra.Data.Users;
using SHS.Infrastructu.Encrypt;
using SHS.Service.Interfaces;
using SHS.Service.UsersService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SHS.Service.UsersService
{
    public class UserService : IUserService
    {
        private readonly IRepository<Rolepermission> _roleRepository;
        private readonly IRepository<User> _repository;
        private readonly ILogger<UserService> _logger;
        public UserService(IRepository<User> repository, ILogger<UserService> logger, IRepository<Rolepermission> roleRepository)
        {
            _logger = logger;
            _repository = repository;
            _roleRepository = roleRepository;
        }
        public async Task<Result> Add(User user)
        {
            try
            {
                if (user != null)
                {
                    user.Icon = "https://tse1-mm.cn.bing.net/th?id=OIP.VWs6ip-0SNpR7Yof8YYfCgAAAA&w=152&h=160&c=8&rs=1&qlt=90&pid=3.1&rm=2";//系统默认头像
                    user.Password = MD5Encrypt.EncryptBy32(user.Password);
                    user.CreateDate = DateTime.Now;
                    await _repository.AddByAsync(user);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("用户添加异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

        public async Task<Result> Delete(string id, string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    var entity = _repository.Get(Guid.Parse(id));
                    if (entity != null)
                    {
                        entity.IsDel = 1;
                        entity.DeleteDate = DateTime.Now;
                        entity.DeleteUserId = Guid.Parse(userId);
                        var result = await _repository.RemoveByAsync(entity);
                        if (result > 0)
                        {
                            return Result.Success(200);
                        }
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("用户删除异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }

        }

        public async Task<User> Get(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    return await _repository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("用户获取异常" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<User> GetAll(QueryUserFilter filter)
        {
            var result = new List<User>();
            try
            {
                var query = _repository.GetAll();
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    query = query.Where(x => x.Name == filter.Name || x.Phone == filter.Phone);
                }
                result = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit)
                    .ToList();
                // TODO 密码转换
            }
            catch (Exception ex)
            {
                _logger.LogError("获取异常" + ex.ToString());
            }
            return result;
        }
        public async Task<PagedResultDto<User>> GetAllByAsync(QueryUserFilter filter)
        {
            var result = new PagedResultDto<User>();
            try
            {
                var query = await _repository.GetAllByAsync();
                query = query.Where(x => x.IsDel == 0);
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    query = query.Where(x => x.Name == filter.Name);
                }
                if (!string.IsNullOrWhiteSpace(filter.Phone))
                {
                    query = query.Where(x => x.Phone == filter.Phone);
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

        public async Task<User> GetUserInfo(string name, string password)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password))
            {
                var users = await _repository.GetAllByAsync();
                var user = users.FirstOrDefault(x => x.Name == name || x.Email == name || x.Phone == name);
                if (user != null)
                {
                    var md5Password = MD5Encrypt.EncryptBy32(password);
                    if (user.Password == md5Password)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public async Task<Result> Update(User user)
        {
            try
            {
                if (user != null)
                {
                    user.UpdateDate = DateTime.Now;
                    var result = await _repository.UpdateByAsync(user);
                    if (result > 0)
                    {
                        return Result.Success(200);
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("用户获取异常" + ex.ToString());
                return null;
            }
        }

        public async Task<Result> UserGiveRole(string userId, string roleId)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId.ToString()) && !string.IsNullOrEmpty(roleId.ToString()))
                {
                    var user = _repository.Get(Guid.Parse(userId));
                    var role = _roleRepository.Get(Guid.Parse(roleId));
                    if (user != null && role != null)
                    {
                        user.RoleID = Guid.Parse(roleId);
                        return await Update(user);
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("用户赋予角色异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }

    }
}
