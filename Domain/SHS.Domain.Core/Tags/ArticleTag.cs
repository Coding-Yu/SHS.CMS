using SHS.Domain.Core.Articles;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Tags
{
    [Table("SHS.CMS.ArticleTag")]
    public class ArticleTag
    {
        public Guid ID { get; set; }
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
