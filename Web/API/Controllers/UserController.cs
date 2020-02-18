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
        public async Task<JsonResult> Add(AddOrEditUserModel model)
        {
            //TODO CreateUserId当前用户人
            var area = new Area();
            var user = new UserDto();
            user.Password = model.Password;
            user.Name = model.Name;
            user.Phone = model.Phone;
            user.RoleID = Guid.Parse(model.RoleID);
            user.Sex = model.Sex;
            user.Age = model.Age;
            user.Area = area;
            user.Email = model.Email;
            user.CreateDate = DateTime.Now;
            var result = await _userAppService.AddUser(user);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpPost("Update")]
        public async Task<JsonResult> Update(AddOrEditUserModel model)
        {
            var area = new Area();
            var user = new UserDto();
            user.Password = model.Password;
            user.Name = model.Name;
            user.Phone = model.Phone;
            user.RoleID = Guid.Parse(model.RoleID);
            user.Sex = model.Sex;
            user.Age = model.Age;
            user.Area = area;
            user.Email = model.Email;
            user.UpdateDate = DateTime.Now;
            user.ID =Guid.Parse(model.Id.ToUpper());
            //user.Area = area;user.UpdateUserId='';
            // TODO 传递后进行赋值
            var result = await _userAppService.UpdateUser(user);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Delete")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _userAppService.Delete(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpPost("GetUserInfo")]
        public async Task<JsonResult> GetUserInfo(GetUserInfoModel model)
        {
            return new JsonResult(await _userAppService.GetUserInfo(model.Username, model.Password));
        }
    }
}