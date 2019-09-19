using SHS.Domain.Core.Roles;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Permissions
{
    [Table("SHS.CMS.RolePermission")]
    public class RolePermission
    {
        public Guid ID { get; set; }
        public Guid RoleId { get; set; }
        public Role role { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
