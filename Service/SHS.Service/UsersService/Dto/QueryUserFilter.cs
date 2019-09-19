using SHS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Service.UsersService.Dto
{
    public class QueryUserFilter : QueryPageInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
