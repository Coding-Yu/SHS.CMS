using AutoMapper;
using SHS.Application.Base;
using SHS.Application.LogAppService.Dtos;
using SHS.Service.LogService;
using SHS.Service.LogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Application.LogAppService
{
    public class LogAppService : ILogAppService
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        public LogAppService(ILogService logService, IMapper mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<LogDto>> GetAll(QueryLogFilter filter)
        {
            var result = new Base.PagedResultDto<LogDto>();
            var categorys = await _logService.GetAll(filter);
            result.Items = _mapper.Map<List<LogDto>>(categorys.Items);
            result.TotalCount = categorys.TotalCount;
            return result;
        }
    }
}
