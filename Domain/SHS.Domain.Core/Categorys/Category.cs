using SHS.Domain.Core.Articles;
using SHS.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Categorys
{
    [Table("SHS.CMS.Category")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public List<Article> Article { get; set; }
    }
}
