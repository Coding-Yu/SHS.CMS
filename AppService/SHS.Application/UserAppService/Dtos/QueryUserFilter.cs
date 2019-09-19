using SHS.Domain.Core.Interfaces;

namespace SHS.Application.UserAppService.Dtos
{
    public class QueryUserFilter: QueryPageInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
