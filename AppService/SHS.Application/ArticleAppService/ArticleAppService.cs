using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SHS.Application.ArticleAppService.Dtos;
using SHS.Application.Base;
using SHS.Domain.Core.Articles;
using SHS.Service.ArticleService;
using SHS.Service.Interfaces;
using SHS.Service.UsersService;

namespace SHS.Application.ArticleAppService
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleAppService(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        public async Task<Result> Add(AddArticleDto dto)
        {
            return await _articleService.Add(_mapper.Map<Article>(dto));
        }

        public async Task<Result> Delete(string id,string userId)
        {
            return await _articleService.Delete(id, userId);
        }

        public async Task<ArticleDto> Get(string id)
        {
            var entity = await _articleService.Get(id);
            var result =_mapper.Map<ArticleDto>(entity);
            return result;
        }

        public async Task<Base.PagedResultDto<ArticleDto>> GetAll(QueryArticleFilter filter)
        {
            var result = new Base.PagedResultDto<ArticleDto>();
            var articles = await _articleService.GetAll(new Service.ArticleService.Dto.QueryArticleFilter()
            {
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
                title = filter.title,
            });
           
            result.Items =_mapper.Map<List<ArticleDto>>(articles.Items);
            result.TotalCount = articles.TotalCount;
            return result;
        }

        public async Task<Result> Update(ModifyArticleDto dto)
        {
            return await _articleService.Update(_mapper.Map<Article>(dto));
        }
    }
}
