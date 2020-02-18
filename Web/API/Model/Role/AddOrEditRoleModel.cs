using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.Role
{
    public class AddOrEditRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Remarks { get; set; }
        public string Summary { get; set; }
    }
}
