using SHS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Service.RoleService.Dto
{
   public class QueryRoleFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
