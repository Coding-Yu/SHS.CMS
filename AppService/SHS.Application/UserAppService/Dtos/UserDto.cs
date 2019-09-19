using AutoMapper;
using SHS.Infra.Data.Users;
using System;

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
        public int Area { get; set; }
        public Guid RoleID { get; set; }
    }
}
