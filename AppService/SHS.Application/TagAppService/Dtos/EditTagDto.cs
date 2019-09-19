using SHS.Application.Base;

namespace SHS.Application.TagAppService.Dtos
{
    public class EditTagDto : BaseDto
    {
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}
