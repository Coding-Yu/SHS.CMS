using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.Article
{
    public class AddOrEditArticleModel
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string SourceLink { get; set; }

        public string CategoryId { get; set; }

        public IList<string> TagIds { get; set; }
    }
}
