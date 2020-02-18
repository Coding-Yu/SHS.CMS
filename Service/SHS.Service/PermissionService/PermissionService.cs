using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PermissionService> _logger;
        public PermissionService(IRepository<Permission> permissionRepository, ILogger<PermissionService> logger)
        {
            _logger = logger;
            _permissionRepository = permissionRepository;
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

        public async Task<Result> Delete(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    await _permissionRepository.RemoveByAsync(Guid.Parse(id));
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

        public async Task<IEnumerable<Permission>> GetAll(QueryPermissionFilter filter)
        {
            var result = new List<Permission>();
            try
            {
                var query = await _permissionRepository.GetAllByAsync();
                if (!string.IsNullOrWhiteSpace(filter.name))
                {
                    query = query.Where(x => x.Name == filter.name);
                }
                result = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
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
                if (permission!=null)
                {
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
    }
}
