using Microsoft.AspNetCore.Mvc;
using SHS.Application.RoleAppService;
using SHS.Application.RoleAppService.Dtos;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleAppService _roleAppService;
        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList(QueryRoleFilter filter)
        {
            var result = await _roleAppService.GetAll(filter);
            return Json(result);
        }
        [HttpGet("{Get}")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _roleAppService.Get(id);
            return Json(result);
        }

        [HttpDelete("{Add}")]
        public async Task<JsonResult> Add()
        {
            var result = await _roleAppService.AddAsync(new RoleDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Update}")]
        public async Task<JsonResult> Update()
        {
            var result = await _roleAppService.Update(new RoleDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _roleAppService.Delete(id);
            return Json(result);
        }
    }
}