using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Categorys;

namespace SHS.Application.CategoryAppService.Dtos
{
    [AutoMap(typeof(Category))]
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public string Summary { get; set; }
    }
}
