using SHS.Domain.Core.Interfaces;
using SHS.Domain.Core.Permissions;
using SHS.Infra.Data.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Roles
{
    [Table("SHS.CMS.Role")]
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public bool IsDefault { get; set; }
        public List<User> Users { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
    }
}
