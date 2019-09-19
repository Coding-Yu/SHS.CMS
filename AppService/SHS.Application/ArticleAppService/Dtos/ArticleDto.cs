using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Articles;

namespace SHS.Application.ArticleAppService.Dtos
{
    [AutoMap(typeof(Article))]
   public class ArticleDto:BaseDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string SourceLink { get; set; }

        public string CategoryId { get; set; }

    }
}
