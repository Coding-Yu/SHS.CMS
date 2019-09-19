using Microsoft.AspNetCore.Mvc;
using SHS.Application.TagAppService;
using SHS.Application.TagAppService.Dtos;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagAppService _tagAppService;

        public TagController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }
       

        [HttpPost("GetList")]
        public async Task<JsonResult> GetList(QueryTagFilter filter)
        {
            var result = await _tagAppService.GetAll(filter);
            return Json(result);
        }
        [HttpGet("{Get}")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _tagAppService.Get(id);
            return Json(result);
        }

        [HttpDelete("{Add}")]
        public async Task<JsonResult> Add()
        {
            var result = await _tagAppService.Add(new TagDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Update}")]
        public async Task<JsonResult> Update()
        {
            var result = await _tagAppService.Update(new TagDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _tagAppService.Delete(id);
            return Json(result);
        }
    }
}