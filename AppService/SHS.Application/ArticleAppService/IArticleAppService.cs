using SHS.Application.ArticleAppService.Dtos;
using SHS.Application.Base;
using SHS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Application.ArticleAppService
{
    public interface IArticleAppService
    {
        Task<Result> Add(AddArticleDto article);
        Task<Base.PagedResultDto<ArticleDto>> GetAll(QueryArticleFilter filter);
        Task<Result> Update(ModifyArticleDto article);
        Task<ArticleDto> Get(string id);
        Task<Result> Delete(string id,string userId);
    }
}
