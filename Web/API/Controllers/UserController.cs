using API.Model.AuthenticationModel;
using API.Model.User;
using API.User.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.UserAppService;
using SHS.Application.UserAppService.Dtos;
using SHS.Domain.Core.Area;
using System;
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
        public async Task<JsonResult> GetList()
        {
            QueryUserFilter filter = new QueryUserFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.name = Request.Query["name"];
            filter.phone = Request.Query["phone"];
            var result = await _userAppService.GetAllByAsync(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpPost("Get")]
        public async Task<JsonResult> Get(GetUserInputModel input)
        {
            var result = await _userAppService.GetUser(input.id);
            return new JsonResult(result);
        }
        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddUserDto model)
        {
            var result = await _userAppService.AddUser(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpPost("Update")]
        public async Task<JsonResult> Update(ModifyUserDto model)
        {
            var result = await _userAppService.UpdateUser(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Delete")]
        public async Task<JsonResult> Delete(string id, string userId)
        {
            var result = await _userAppService.Delete(id, userId);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}