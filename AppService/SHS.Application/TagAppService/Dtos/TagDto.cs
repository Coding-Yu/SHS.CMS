using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Tags;

namespace SHS.Application.TagAppService.Dtos
{
    [AutoMap(typeof(Tag))]
    public class TagDto:BaseDto
    {
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}
