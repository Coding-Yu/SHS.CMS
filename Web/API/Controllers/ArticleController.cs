using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.ArticleAppService;
using SHS.Application.ArticleAppService.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpPost("GetList")]
        public async Task<JsonResult> GetList(QueryArticleFilter filter)
        {
            var result = await _articleAppService.GetAll(filter);
            return Json(result);
        }
        [HttpGet("{Get}")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _articleAppService.Get(id);
            return Json(result);
        }

        [HttpDelete("{Add}")]
        public async Task<JsonResult> Add()
        {
            var result = await _articleAppService.Add(new ArticleDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Update}")]
        public async Task<JsonResult> Update()
        {
            var result = await _articleAppService.Update(new ArticleDto()
            {

            });
            return Json(result);
        }

        [HttpDelete("{Delete}")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _articleAppService.Delete(id);
            return Json(result);
        }
    }
}