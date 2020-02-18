using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.User.Model
{
    public class AddOrEditUserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password{ get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public int Area { get; set; }
        public string RoleID { get; set; }
        public string Remarks { get; set; }
    }
}
