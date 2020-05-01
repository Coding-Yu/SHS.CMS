using SHS.Domain.Core.Area;
using SHS.Domain.Core.Interfaces;
using SHS.Domain.Core.Roles;
using SHS.Infrastructu.Encrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Infra.Data.Users
{
    [Table("SHS.CMS.User")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password{get;set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public int DetailAddress { get; set; }

        public string Icon { get; set; }

        public Guid RoleID { get; set; }
        public Rolepermission Role { get; set; }

        public Guid AreaID { get; set; }
        public  Area Area { get; set; }

        public string LastLoginIp { get; set; }

        public DateTime LastLoginDate { get; set; }
    }
}
