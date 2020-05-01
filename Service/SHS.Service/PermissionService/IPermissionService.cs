using SHS.Domain.Core.Permissions;
using SHS.Service.Interfaces;
using SHS.Service.PermissionService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Service.PermissionService
{
    public interface IPermissionService
    {
        Task<Result> Add(Permission permission);

        Task<Permission> Get(string id);

        Task<PagedResultDto<Permission>> GetAll(QueryPermissionFilter filter);
        Task<Result> Update(Permission permission);

        Task<Result> Delete(string id, string userId);

    }
}
