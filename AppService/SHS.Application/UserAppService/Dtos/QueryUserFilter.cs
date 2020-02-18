using SHS.Domain.Core.Interfaces;

namespace SHS.Application.UserAppService.Dtos
{
    public class QueryUserFilter: QueryPageInput
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
}
