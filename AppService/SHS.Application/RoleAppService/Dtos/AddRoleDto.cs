using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Roles;
using System;
using System.Collections.Generic;

namespace SHS.Application.RoleAppService.Dtos
{
    [AutoMap(typeof(Rolepermission))]
    public class AddRoleDto : BaseDto
    {
        public AddRoleDto()
        {
            CreateDate = DateTime.Now;
        }
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public string Summary { get; set; }
    }
}
