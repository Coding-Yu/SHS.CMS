using API.Model.User;
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
    public class UserController : ControllerBase
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
            return new JsonResult(result);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _userAppService.GetUser(id);
            return new JsonResult(result);
        }
        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddUserModel model)
        {
            var result = await _userAppService.AddUser(new UserDto()
            {

            });
            return new JsonResult(result);
        }
        [HttpPut("Update")]
        public async Task<JsonResult> Update(AddUserModel model)
        {
            var result = await _userAppService.UpdateUser(new UserDto()
            {

            });
            return new JsonResult(result);
        }
        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _userAppService.Delete(id);
            return new JsonResult(result);
        }
        [HttpPost("SetRole")]
        public async Task<JsonResult> SetRole(string userId, string roleId)
        {
            return new JsonResult(await _userAppService.SetRole(userId, roleId));
        }

        public async Task<JsonResult> GetUserInfo(GetUserInfoModel model)
        {
            return new JsonResult(await _userAppService.GetUserInfo(model.Username,model.Password));
        }
    }
}