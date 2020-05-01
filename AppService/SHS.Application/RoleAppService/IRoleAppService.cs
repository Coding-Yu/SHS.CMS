using SHS.Application.RoleAppService.Dtos;
using SHS.Domain.Core.Permissions;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.RoleAppService
{
    public interface IRoleAppService
    {
        Task<RoleDto> Get(string id);

        Task<Base.PagedResultDto<RoleDto>> GetAll(QueryRoleFilter filter);
        Task<Result> AddAsync(AddRoleDto role);

        Task<Result> Update(ModifyRoleDto role);

        Task<Result> Delete(string id,string userId);

        Task<Result> RoleGivePermission(string roleid, IList<string> permissionIds);

        Task<IList<Permission>> GetPermissionByRoleId(string id);
    }
}
