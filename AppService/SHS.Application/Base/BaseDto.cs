using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Application.Base
{
   public class BaseDto
    {
        public string ID { get; set; }

        public long Sort { get; set; }
        public int IsDel { get; set; }

        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid UpdateUserId { get; set; }

        public DateTime UpdateDate { get; set; }

        public long DeleteUserId { get; set; }

        public DateTime DeleteDate { get; set; }
        public string Remarks { get; set; }
    }
}
