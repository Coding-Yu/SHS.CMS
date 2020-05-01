using SHS.Application.TagAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.TagAppService
{
    public interface ITagAppService
    {
        Task<Result> Add(AddTagDto tag);
        Task<Base.PagedResultDto<TagDto>> GetAll(QueryTagFilter filter);
        Task<Result> Update(ModifyTagDto tag);
        Task<TagDto> Get(string id);
        Task<Result> Delete(string id,string userId);
    }
}
