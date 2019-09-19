using SHS.Application.PermissionAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.PermissionAppService
{
    public interface IPermissionAppService
    {
        Task<Result> Add(PermiisionDto permission);

        Task<PermiisionDto> Get(string id);

        Task<IEnumerable<PermiisionDto>> GetAll( QueryPermissionFilter filter);
        Task<Result> Update(PermiisionDto permiision);

        Task<Result> Delete(string id);
    }
}
