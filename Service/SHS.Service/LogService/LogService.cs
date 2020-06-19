using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHS.Domain.Core.Logger;
using SHS.Domain.Repository.Interfaces;
using SHS.Service.Interfaces;
using SHS.Service.LogService.Dto;

namespace SHS.Service.LogService
{
    public class LogService : ILogService
    {
        private readonly IRepository<Log> _logRepository;
        public LogService(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<PagedResultDto<Log>> GetAll(QueryLogFilter filter)
        {
            var result = new PagedResultDto<Log>();
            var query = await _logRepository.GetAllByAsync();
            result.TotalCount = query.Count();
            result.Items = query.OrderByDescending(x => x.Logged).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
            return result;
        }
    }
}
