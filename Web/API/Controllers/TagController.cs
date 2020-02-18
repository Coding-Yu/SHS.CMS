using API.Model.AuthenticationModel;
using API.Model.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.TagAppService;
using SHS.Application.TagAppService.Dtos;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagAppService _tagAppService;

        public TagController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }
       

        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {

            QueryTagFilter filter = new QueryTagFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.name = Request.Query["name"];
            var result = await _tagAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _tagAppService.Get(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddOrEditTagModel model)
        {
            AddTagDto tag = new AddTagDto();
            tag.Name = model.Name;
            tag.Summary = model.Summary;
            tag.CreateDate = DateTime.Now;
            // TODO 用户ID tag.CreateUserId = 1;
            var result = await _tagAppService.Add(tag);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(AddOrEditTagModel model)
        {
            EditTagDto tag = new EditTagDto();

            tag.Name = model.Name;
            tag.Summary = model.Summary;
            tag.UpdateDate = DateTime.Now;
            // TODO 用户IDtag.UpdateUserId=1;
            var result = await _tagAppService.Update(tag);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id)
        {
            var result = await _tagAppService.Delete(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}