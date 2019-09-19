using SHS.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Tags
{
    [Table("SHS.CMS.Tag")]
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public List<ArticleTag> ArticleTag { get; set; }
    }
}
