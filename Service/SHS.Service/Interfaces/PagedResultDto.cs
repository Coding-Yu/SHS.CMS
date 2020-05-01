using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Service.Interfaces
{
    public class PagedResultDto<T>
    {
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Items { get; set; }
    }
}
