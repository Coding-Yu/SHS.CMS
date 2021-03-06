﻿using AutoMapper;
using SHS.Application.Base;
using SHS.Infra.Data.Users;

namespace SHS.Application.UserAppService.Dtos
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class AddUserDto : BaseDto
    {
        private string password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public string areaId { get; set; }
        public string Icon { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public int DetailAddress { get; set; }
        public string RoleID { get; set; }

        public string AddressId { get; set; }

        public string LastLoginIp { get; set; }
    }
}
