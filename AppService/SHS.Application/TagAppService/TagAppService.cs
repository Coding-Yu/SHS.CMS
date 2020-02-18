using AutoMapper;
using SHS.Application.TagAppService.Dtos;
using SHS.Domain.Core.Tags;
using SHS.Service.Interfaces;
using SHS.Service.TagService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.TagAppService
{
    public class TagAppService : ITagAppService
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagAppService(ITagService tagService, IMapper mapper)
        {
            _mapper = mapper;
            _tagService = tagService;
        }
        public async Task<Result> Add(AddTagDto tag)
        {
            return await _tagService.Add(_mapper.Map<Tag>(tag));
        }

        public async Task<Result> Delete(string id)
        {
            return await _tagService.Delete(id);
        }

        public async Task<TagDto> Get(string id)
        {
            return _mapper.Map<TagDto>(await _tagService.Get(id));
        }

        public async Task<IEnumerable<TagDto>> GetAll(QueryTagFilter filter)
        {
            var result = new List<TagDto>();
            var tags = await _tagService.GetAll(new Service.TagService.Dto.QueryTagFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
            });
            foreach (var item in tags)
            {
                result.Add(_mapper.Map<TagDto>(item));
            }
            return result;
        }

        public async Task<Result> Update(EditTagDto tag)
        {
            return await _tagService.Update(_mapper.Map<Tag>(tag));
        }
    }
}
