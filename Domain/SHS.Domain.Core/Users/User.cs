using SHS.Domain.Core.Area;
using SHS.Domain.Core.Interfaces;
using SHS.Domain.Core.Roles;
using SHS.Infrastructu.Encrypt;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Infra.Data.Users
{
    [Table("SHS.CMS.User")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password{get;set; }//password = MD5Encrypt.EncryptBy32(password);
        public int Sex { get; set; }
        public int Age { get; set; }
        public int DetailAddress { get; set; }
        public Guid RoleID { get; set; }
        public Role Role { get; set; }

        public Guid AreaID { get; set; }
        public Area Area { get; set; }
    }
}
