using SHS.Domain.Core.Interfaces;

namespace SHS.Application.ArticleAppService.Dtos
{
    public class QueryArticleFilter : QueryPageInput
    {
        public  string title { get; set; }
    }
}
