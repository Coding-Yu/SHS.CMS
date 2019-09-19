using AutoMapper;
using SHS.Application.Base;
using SHS.Infra.Data.Users;

namespace SHS.Application.UserAppService.Dtos
{
    [AutoMap(typeof(User))]
    public class EditUserDto : BaseDto
    {

        private string password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public int DetailAddress { get; set; }
        public string RoleID { get; set; }

        public string AddressId { get; set; }
    }
}
