using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Permissions;
using System;
using System.Collections.Generic;

namespace SHS.Application.PermissionAppService.Dtos
{
    [AutoMap(typeof(Permission))]
    public class AddPermissionDto:BaseDto
    {
        public AddPermissionDto()
        {
            CreateDate = DateTime.Now;
        }
        public string Name { get; set; }

        public string Path { get; set; }
    }
}
