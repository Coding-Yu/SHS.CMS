using API.Model.AuthenticationModel;
using API.Model.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.RoleAppService;
using SHS.Application.RoleAppService.Dtos;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {
            QueryRoleFilter filter = new QueryRoleFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.Name = Request.Query["name"];
            var result = await _roleAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _roleAppService.Get(id);
            return new JsonResult(result);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddRoleDto model)
        {
            var result = await _roleAppService.AddAsync(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(ModifyRoleDto model)
        {
            var result = await _roleAppService.Update(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id, string userId)
        {
            var result = await _roleAppService.Delete(id, userId);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("SetPermission")]
        public async Task<JsonResult> SetPermission(SetPermissionModel model)
        {
            var result = await _roleAppService.RoleGivePermission(model.RoleID, model.PermissionIds);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("GetPermissionByRoleId")]
        public async Task<JsonResult> GetPermissionByRoleId(string id)
        {
            var result = await _roleAppService.GetPermissionByRoleId(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}