using SHS.Domain.Core.Interfaces;

namespace SHS.Service.TagService.Dto
{
    public class QueryTagFilter: QueryPageInput
    {
        public string name { get; set; }
    }
}
