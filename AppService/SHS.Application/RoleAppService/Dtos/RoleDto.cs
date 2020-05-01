using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Infra.Data.Users;
using System;
using System.Collections.Generic;

namespace SHS.Application.RoleAppService.Dtos
{
    [AutoMap(typeof(Rolepermission))]
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        
        public string Summary { get; set; }
    }
}
