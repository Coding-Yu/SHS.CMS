using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using API.Model.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.CategoryAppService;
using SHS.Application.CategoryAppService.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {
            QueryCategoryFilter filter = new QueryCategoryFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.name = Request.Query["name"];
            var result = await _categoryAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _categoryAppService.Get(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddCategoryDto model )
        {
            var result = await _categoryAppService.Add(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(ModifyCategoryDto model)
        {
            var result = await _categoryAppService.Update(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id,string userId)
        {
            var result = await _categoryAppService.Delete(id,userId);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}