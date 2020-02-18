using SHS.Application.TagAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.TagAppService
{
    public interface ITagAppService
    {
        Task<Result> Add(AddTagDto tag);
        Task<IEnumerable<TagDto>> GetAll(QueryTagFilter filter);
        Task<Result> Update(EditTagDto tag);
        Task<TagDto> Get(string id);
        Task<Result> Delete(string id);
    }
}
