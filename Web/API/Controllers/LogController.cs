using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model.AuthenticationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHS.Application.LogAppService;
using SHS.Service.LogService.Dto;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly ILogAppService _logAppService;
        public LogController(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }
        [HttpPost("GetList")]
        public async Task<JsonResult> GetList()
        {
            QueryLogFilter filter = new QueryLogFilter();
            filter.limit = int.Parse(Request.Query["limit"]);
            filter.page = int.Parse(Request.Query["page"]);
            var result = await _logAppService.GetAll(filter);
            OutputModel outputModel = new OutputModel();
            outputModel.Data = result;
            return new JsonResult(outputModel);
        }
    }
}