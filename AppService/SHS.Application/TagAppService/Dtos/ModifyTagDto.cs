using SHS.Application.Base;

namespace SHS.Application.TagAppService.Dtos
{
    public class ModifyTagDto : BaseDto
    {
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}
