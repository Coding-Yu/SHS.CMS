using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Categorys;
using System;
using System.Collections.Generic;

namespace SHS.Application.CategoryAppService.Dtos
{
    [AutoMap(typeof(Category))]
    public class AddCategoryDto : BaseDto
    {
        public AddCategoryDto()
        {
            CreateDate = DateTime.Now;
        }
        public string Name { get; set; }

        public string Summary { get; set; }

        public List<string> Article { get; set; }
    }
}
