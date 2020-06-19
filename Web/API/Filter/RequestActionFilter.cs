using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Filter
{
    public class RequestActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 全局请求ID号
        /// </summary>
        private static Int64 ActionId { get; set; }
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        private String ClientIp { get; set; }
        /// <summary>
        /// 请求ID号
        /// </summary>
        private Int64 RequestId { get; set; }

        /// <summary>
        /// 请求的接口
        /// </summary>
        private String URL { get; set; }
        private string Method { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            RequestId = ActionId++;
            URL = context.HttpContext.Request.Host.Value + context.HttpContext.Request.Path;
            Method = context.HttpContext.Request.Method;
            ClientIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            String message = String.Format("当前时间：{0},请求ID：[{1}]，客户端IP：[{2}]，请求地址：[{3}]，请求方法：[{3}]", DateTime.Now, RequestId, ClientIp, URL, Method);
            var fileLog = LogManager.GetLogger("logfile");
            fileLog.Info(message);
        }
    }
}
