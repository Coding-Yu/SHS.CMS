using SHS.Application.RoleAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.RoleAppService
{
    public interface IRoleAppService
    {
        Task<RoleDto> Get(string id);

        Task<IEnumerable<RoleDto>> GetAll(QueryRoleFilter filter);
        Task<Result> AddAsync(RoleDto role);

        Task<Result> Update(RoleDto role);

        Task<Result> Delete(string id);

        Task<Result> RoleGivePermission(string roleid, List<string> permissionIds);
    }
}
