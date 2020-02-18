using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SHS.Application.ArticleAppService.Dtos;
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
        public async Task<Result> Add(AddArticleDto article)
        {
            return await _articleService.Add(_mapper.Map<Article>(article));
        }

        public async Task<Result> Delete(string id)
        {
            return await _articleService.Delete(id);
        }

        public async Task<ArticleDto> Get(string id)
        {
            return _mapper.Map<ArticleDto>(await _articleService.Get(id));
        }

        public async Task<IEnumerable<ArticleDto>> GetAll(QueryArticleFilter filter)
        {
            var result = new List<ArticleDto>();
            var articles = await _articleService.GetAll(new Service.ArticleService.Dto.QueryArticleFilter()
            {
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
                title = filter.title,
            });
            foreach (var item in articles)
            {
                result.Add(_mapper.Map<ArticleDto>(item));
            }
            return result;
        }

        public async Task<Result> Update(ModifyArticleDto article)
        {
            return await _articleService.Update(_mapper.Map<Article>(article));
        }
    }
}
