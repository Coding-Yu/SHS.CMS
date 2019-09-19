using SHS.Domain.Core.Interfaces;

namespace SHS.Service.PermissionService.Dto
{
    public class QueryPermissionFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
