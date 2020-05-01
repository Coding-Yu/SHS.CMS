using AutoMapper;
using SHS.Domain.Core.Area;
using SHS.Infra.Data.Users;
using System;
using System.Collections.Generic;

namespace SHS.Application.UserAppService.Dtos
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class UserDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public Guid AreaID { get; set; }
        public Area Area { get; set; }
        public string Remarks { get; set; }
        public Guid RoleID { get; set; }
        public string Icon { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public DateTime UpdateDate { get; set; }

        public string LastLoginIp { get; set; }

    }
}
