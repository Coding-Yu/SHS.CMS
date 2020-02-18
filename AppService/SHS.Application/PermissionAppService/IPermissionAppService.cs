using SHS.Application.PermissionAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.PermissionAppService
{
    public interface IPermissionAppService
    {
        Task<Result> Add(AddPermissionDto permission);

        Task<PermissionDto> Get(string id);

        Task<IEnumerable<PermissionDto>> GetAll( QueryPermissionFilter filter);
        Task<Result> Update(ModifyPermissionDto permiision);

        Task<Result> Delete(string id);
    }
}
