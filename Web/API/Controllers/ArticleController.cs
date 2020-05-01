using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using AutoMapper;
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
        public readonly IMapper _mapper;
        public ArticleController(IArticleAppService articleAppService, IMapper mapper)
        {
            _articleAppService = articleAppService;
            _mapper = mapper;
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
        public async Task<JsonResult> Add(AddArticleDto model)
        {
            var result = await _articleAppService.Add(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(ModifyArticleDto model)
        {
            var result = await _articleAppService.Update(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id, string userId)
        {
            var result = await _articleAppService.Delete(id, userId);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}