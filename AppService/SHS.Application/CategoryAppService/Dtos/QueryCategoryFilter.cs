using SHS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Application.CategoryAppService.Dtos
{
   public class QueryCategoryFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
