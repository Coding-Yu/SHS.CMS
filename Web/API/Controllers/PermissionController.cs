using Microsoft.AspNetCore.Mvc;
using SHS.Application.PermissionAppService;
using SHS.Application.PermissionAppService.Dtos;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList(QueryPermissionFilter filter)
        {
            var result = await _permissionAppService.GetAll(filter);
            return Json(result);
        }
        [HttpGet("{Get}")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _permissionAppService.Get(id);
            return Json(result);
        }

        [HttpDelete("{Add}")]
        public async Task<JsonResult> Add()
        {
            var result = await _permissionAppService.Add(new PermiisionDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Update}")]
        public async Task<JsonResult> Update()
        {
            var result = await _permissionAppService.Update(new PermiisionDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _permissionAppService.Delete(id);
            return Json(result);
        }
    }
}