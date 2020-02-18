using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.Role
{
    public class SetPermissionModel
    {
        public string RoleID { get; set; }
        public IList<string> PermissionIds { get; set; }
    }
}
