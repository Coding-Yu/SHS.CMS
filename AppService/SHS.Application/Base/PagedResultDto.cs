using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Application.Base
{
    public class PagedResultDto<T>
    {
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Items { get; set; }
    }
}
