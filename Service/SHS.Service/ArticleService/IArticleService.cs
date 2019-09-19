using SHS.Domain.Core.Articles;
using SHS.Service.ArticleService.Dto;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Service.ArticleService
{
    public interface IArticleService
    {
        Task<Result> Add(Article article);
        Task<IEnumerable<Article>> GetAll(QueryArticleFilter filter);
        Task<Result> Update(Article article);
        Task<Article> Get(string id);
        Task<Result> Delete(string id);
    }
}
