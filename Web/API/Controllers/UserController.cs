using API.User.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.UserAppService;
using SHS.Application.UserAppService.Dtos;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList(QueryUserFilter filter)
        {
            var result = await _userAppService.GetAllByAsync(filter);
            return Json(result);
        }
        [HttpGet("{Get}")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _userAppService.GetUser(id);
            return Json(result);
        }
        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddUserModel model)
        {
            var result = await _userAppService.AddUser(new UserDto()
            {

            });
            return Json(result);
        }
        [HttpPut("Update")]
        public async Task<JsonResult> Update(AddUserModel model)
        {
            var result = await _userAppService.UpdateUser(new UserDto()
            {

            });
            return Json(result);
        }
        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _userAppService.Delete(id);
            return Json(result);
        }
        [HttpPost("SetRole")]
        public async Task<JsonResult> SetRole(string userId, string roleId)
        {
            return Json(await _userAppService.SetRole(userId, roleId));
        }
        [HttpPost("Login")]
        public async Task<JsonResult> Login(string name, string passsword)
        {
            return Json(await _userAppService.Login(name, passsword));
        }

       
    }
}