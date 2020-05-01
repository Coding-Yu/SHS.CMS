using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.Category
{
    public class AddOrEditCategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Summary { get; set; }

        public string Remarks { get; set; }
    }
}
