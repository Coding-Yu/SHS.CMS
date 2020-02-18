using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Permissions;
using System.Collections.Generic;

namespace SHS.Application.PermissionAppService.Dtos
{

    [AutoMap(typeof(PermissionDto))]
    public class ModifyPermissionDto:BaseDto
    {
        public string Name { get; set; }

        public string Path { get; set; }
    }
}
