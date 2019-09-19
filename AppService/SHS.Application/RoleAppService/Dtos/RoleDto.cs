using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Roles;
using System;
using System.Collections.Generic;

namespace SHS.Application.RoleAppService.Dtos
{
    [AutoMap(typeof(Role))]
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public List<Guid> UserId { get; set; }
    }
}
