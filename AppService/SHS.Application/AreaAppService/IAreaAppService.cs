using SHS.Application.AreaAppService.Dtos;
using SHS.Service.Interfaces;
using System.Threading.Tasks;

namespace SHS.Application.AreaAppService
{
    public interface IAreaAppService
    {

        Task<Result> Add(AddAreaDto area);
        Task<Base.PagedResultDto<AreaDto>> GetAll(QueryAreaFilter filter);
        Task<Result> Update(ModifyAreaDto area);
        Task<AreaDto> Get(string id);
        Task<Result> Delete(string id, string userId);
    }
}
