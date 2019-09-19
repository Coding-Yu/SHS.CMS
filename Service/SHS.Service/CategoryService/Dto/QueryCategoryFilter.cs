using SHS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Service.CategoryService.Dto
{
   public class QueryCategoryFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
