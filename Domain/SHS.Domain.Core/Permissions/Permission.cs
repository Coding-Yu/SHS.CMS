using SHS.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHS.Domain.Core.Permissions
{
    [Table("SHS.CMS.Permission")]
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
    }
}
