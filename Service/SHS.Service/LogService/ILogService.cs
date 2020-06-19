using SHS.Domain.Core.Logger;
using SHS.Service.Interfaces;
using SHS.Service.LogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Service.LogService
{
    public interface ILogService
    {
        Task<PagedResultDto<Log>> GetAll(QueryLogFilter filter);
    }
}
