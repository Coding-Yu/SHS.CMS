using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.AreaAppService;
using SHS.Application.AreaAppService.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AreaController : ControllerBase
    {
        private readonly IAreaAppService _areaAppService;
        public readonly IMapper _mapper;
        public AreaController(IAreaAppService areaAppService, IMapper mapper)
        {
            _areaAppService = areaAppService;
            _mapper = mapper;
        }

        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {
            QueryAreaFilter filter = new QueryAreaFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            filter.ZipCode = Request.Query["zipCode"];
            var result = await _areaAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
        [HttpGet("Get")]
        public async Task<JsonResult> Get(string id)
        {
            var result = await _areaAppService.Get(id);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Add(AddAreaDto model)
        {
            var result = await _areaAppService.Add(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Update")]
        public async Task<JsonResult> Update(ModifyAreaDto model)
        {
            var result = await _areaAppService.Update(model);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete(string id, string userId)
        {
            var result = await _areaAppService.Delete(id, userId);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }


    }
}