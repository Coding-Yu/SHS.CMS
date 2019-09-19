using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.CategoryAppService;
using SHS.Application.CategoryAppService.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList(QueryCategoryFilter filter)
        {
            var result = await _categoryAppService.GetAll(filter);
            return Json(result);
        }
        [HttpGet("{Get}")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _categoryAppService.Get(id);
            return Json(result);
        }

        [HttpDelete("{Add}")]
        public async Task<JsonResult> Add()
        {
            var result = await _categoryAppService.Add(new CategoryDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Update}")]
        public async Task<JsonResult> Update()
        {
            var result = await _categoryAppService.Update(new CategoryDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _categoryAppService.Delete(id);
            return Json(result);
        }
    }
}