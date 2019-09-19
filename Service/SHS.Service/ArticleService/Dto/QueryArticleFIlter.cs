using SHS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Service.ArticleService.Dto
{
    public class QueryArticleFilter : QueryPageInput
    {
        public  string title { get; set; }
    }
}
