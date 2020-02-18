using API.Model.AuthenticationModel;
using API.Model.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.PermissionAppService;
using SHS.Application.PermissionAppService.Dtos;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : Controller
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {
            QueryPermissionFilter filter = new QueryPermissionFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.name = Request.Query["name"];
            var result = await _permissionAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return Json(outputModel);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _permissionAppService.Get(id);
            return Json(result);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddOrEditPermissionModel model)
        {
            var permission = new AddPermissionDto();
            permission.Name = model.Name;
            permission.Path = model.Path;
            permission.Remarks = model.Remarks;
            permission.CreateDate = DateTime.Now;
            //permission.CreateUserId = 1; TODO 用户ID 
            var result = await _permissionAppService.Add(permission);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return Json(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(AddOrEditPermissionModel model)
        {
            var permission = new ModifyPermissionDto();
            permission.Name = model.Name;
            permission.Path = model.Path;
            permission.UpdateDate = DateTime.Now;
            //permission.UpdateUserId = 1;//TODO 用户ID
            var result = await _permissionAppService.Update(permission);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return Json(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _permissionAppService.Delete(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return Json(outputModel);
        }
    }
}