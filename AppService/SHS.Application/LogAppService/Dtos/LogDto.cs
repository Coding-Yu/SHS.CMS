using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Application.LogAppService.Dtos
{
    public class LogDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// 设备IP
        /// </summary>
        public string MachineIp { get; set; }
        /// <summary>
        /// 记录日志时间
        /// </summary>
        public DateTime Logged { get; set; }

        /// <summary>
        /// 请求方法
        /// </summary>
        public string NetRequestMethod { get; set; }
        /// <summary>
        /// 请求URL
        /// </summary>
        public string NetRequestUrl { get; set; }
        /// <summary>
        /// 事件等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public string Exception { get; set; }
    }
}
