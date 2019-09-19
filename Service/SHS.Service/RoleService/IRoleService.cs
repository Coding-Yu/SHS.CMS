using SHS.Domain.Core.Roles;
using SHS.Service.Interfaces;
using SHS.Service.RoleService.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Service.RoleService
{
    public interface IRoleService
    {
        Task<Role> Get(string id);

        Task<IEnumerable<Role>> GetAll(QueryRoleFilter filter);
        Task<Result> Add(Role role);

        Task<Result> Update(Role role);

        Task<Result> Delete(string id);

        Task<Result> RoleGivePermission(string roleid,List<string> permissionIdss);
    }
}
