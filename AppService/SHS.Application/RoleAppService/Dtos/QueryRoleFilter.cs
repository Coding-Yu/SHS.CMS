using SHS.Domain.Core.Interfaces;

namespace SHS.Application.RoleAppService.Dtos
{
    public class QueryRoleFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
