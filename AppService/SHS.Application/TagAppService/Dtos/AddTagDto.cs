using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Tags;
using System;

namespace SHS.Application.TagAppService.Dtos
{
    [AutoMap(typeof(Tag))]
    public class AddTagDto: BaseDto
    {
        public AddTagDto()
        {
            CreateDate = DateTime.Now;
        }
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}
