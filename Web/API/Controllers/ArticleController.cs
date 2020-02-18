using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model.Article;
using API.Model.AuthenticationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.ArticleAppService;
using SHS.Application.ArticleAppService.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleAppService _articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {
            QueryArticleFilter filter = new QueryArticleFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.title = Request.Query["title"];
            var result = await _articleAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _articleAppService.Get(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddOrEditArticleModel model)
        {
            var article = new AddArticleDto();
            article.Title = model.Title;
            article.Content = model.Content;
            article.SourceLink = model.SourceLink;
            article.CategoryId = model.CategoryId;
            article.CreateDate = DateTime.Now;
            article.TagIds = model.TagIds;
            //article.CreateUserId = 1; TODO 用户ID
            var result = await _articleAppService.Add(article);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(AddOrEditArticleModel model)
        {

            var article = new ModifyArticleDto();
            article.Title = model.Title;
            article.Content = model.Content;
            article.SourceLink = model.SourceLink;
            article.CategoryId = model.CategoryId;
            article.UpdateDate = DateTime.Now;
            article.TagIds = model.TagIds;
            //article.UpdateUserId = 1; TODO 用户ID
            var result = await _articleAppService.Update(article);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _articleAppService.Delete(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}