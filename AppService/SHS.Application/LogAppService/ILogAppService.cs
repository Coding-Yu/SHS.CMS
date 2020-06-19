using SHS.Application.LogAppService.Dtos;
using SHS.Service.LogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Application.LogAppService
{
    public interface ILogAppService
    {
        Task<Base.PagedResultDto<LogDto>> GetAll(QueryLogFilter filter);
    }
}
