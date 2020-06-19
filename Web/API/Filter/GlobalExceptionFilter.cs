using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        //private ILogger<GlobalExceptionFilter> _logger;
        //public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        //{
        //    _logger = logger;
        //}
        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;
            //监控了ip方便定位到底是那台服务器出故障了
            //string ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var dblogger = LogManager.GetLogger("logdb");
            dblogger.Error(new LogEventInfo()
            {
                Message = ex.Message,
                Level = NLog.LogLevel.Error,
                Exception = ex,
            });

        }
    }
}
