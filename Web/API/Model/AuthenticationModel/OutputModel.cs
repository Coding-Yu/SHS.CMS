using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.AuthenticationModel
{
    public class OutputModel
    {
        public OutputModel()
        {
            Code = 20000;
            Data = null;
            Message = string.Empty;
        }
        public int Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
