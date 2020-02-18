using SHS.Domain.Core.Interfaces;

namespace SHS.Application.RoleAppService.Dtos
{
    public class QueryRoleFilter: QueryPageInput
    {
        public string Name { get; set; }
    }
}
