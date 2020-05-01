using SHS.Domain.Core.Area;
using SHS.Service.AreaService.Dto;
using SHS.Service.Interfaces;
using System.Threading.Tasks;

namespace SHS.Service.AreaService
{
    public interface IAreaService
    {
        Task<Result> Add(Area area);
        Task<PagedResultDto<Area>> GetAll(QueryAreaFilter filter);
        Task<Result> Update(Area area);
        Task<Area> Get(string id);
        Task<Result> Delete(string id, string userId);
    }
}
