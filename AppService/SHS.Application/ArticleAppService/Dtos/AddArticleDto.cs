using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Articles;
using System;
using System.Collections.Generic;

namespace SHS.Application.ArticleAppService.Dtos
{
    [AutoMap(typeof(Article))]
    public class AddArticleDto:BaseDto
    {
        public AddArticleDto()
        {
            CreateDate = DateTime.Now;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string SourceLink { get; set; }

        public string CategoryId { get; set; }
        
        public string Summary { get; set; }

        public IList<string> TagIds { get; set; }
    }
}
