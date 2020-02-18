using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.Permission
{
    public class AddOrEditPermissionModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Remarks { get; set; }
    }
}
