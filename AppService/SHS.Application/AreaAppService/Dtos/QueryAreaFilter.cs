using SHS.Domain.Core.Interfaces;

namespace SHS.Application.AreaAppService.Dtos
{
    public class QueryAreaFilter : QueryPageInput
    {
        public string Street { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
