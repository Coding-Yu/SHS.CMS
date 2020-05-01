using SHS.Domain.Core.Categorys;
using SHS.Domain.Core.Interfaces;
using SHS.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Articles
{
    [Table("SHS.CMS.Article")]
    public class Article : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string SourceLink { get; set; }

        public string Summary { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public List<ArticleTag> ArticleTag { get; set; }
    }
}
