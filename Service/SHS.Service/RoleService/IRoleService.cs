using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Service.Interfaces;
using SHS.Service.RoleService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Service.RoleService
{
    public interface IRoleService
    {
        Task<Rolepermission> Get(string id);

        Task<PagedResultDto<Rolepermission>> GetAll(QueryRoleFilter filter);
        Task<Result> Add(Rolepermission role);

        Task<Result> Update(Rolepermission role);

        Task<Result> Delete(string id,string userId);

        Task<Result> RoleGivePermission(string roleid,IList<string> permissionIdss);
        Task<IList<Permission>> GetPermissionByRoleId(string id);
    }
}
