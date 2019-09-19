using SHS.Application.ArticleAppService.Dtos;
using SHS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Application.ArticleAppService
{
    public interface IArticleAppService
    {
        Task<Result> Add(ArticleDto article);
        Task<IEnumerable<ArticleDto>> GetAll(QueryArticleFilter filter);
        Task<Result> Update(ArticleDto article);
        Task<ArticleDto> Get(string id);
        Task<Result> Delete(string id);
    }
}
