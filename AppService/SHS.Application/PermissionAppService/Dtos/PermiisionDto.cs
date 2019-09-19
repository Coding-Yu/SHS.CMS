using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Permissions;

namespace SHS.Application.PermissionAppService.Dtos
{
    [AutoMap(typeof(Permission))]
    public class PermiisionDto : BaseDto
    {
        public string name { get; set; }
    }
}
