using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Domain.Core.Interfaces
{
    public class QueryPageInput
    {
        /// <summary>
        /// 一页显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 显示页数
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 是否顺序
        /// </summary>
        //public bool IsOrder { get; set; }
    }
}
