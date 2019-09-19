using SHS.Domain.Core.Interfaces;

namespace SHS.Application.PermissionAppService.Dtos
{
    public class QueryPermissionFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
