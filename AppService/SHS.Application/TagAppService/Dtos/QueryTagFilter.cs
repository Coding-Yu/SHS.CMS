using AutoMapper;
using SHS.Domain.Core.Interfaces;
using SHS.Domain.Core.Tags;

namespace SHS.Application.TagAppService.Dtos
{
    [AutoMap(typeof(Tag))]
    public class QueryTagFilter : QueryPageInput
    {
        public string name { get; set; }
    }
}
