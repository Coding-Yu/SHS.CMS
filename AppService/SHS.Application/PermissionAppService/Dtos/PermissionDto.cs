using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Permissions;

namespace SHS.Application.PermissionAppService.Dtos
{
    [AutoMap(typeof(Permission))]
    public class PermissionDto : BaseDto
    {
        public string name { get; set; }
        public string path { get; set; }
    }
}
