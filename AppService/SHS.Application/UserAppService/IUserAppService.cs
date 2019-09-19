
using SHS.Application.UserAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.UserAppService
{
    public interface IUserAppService
    {
        Task<Result> AddUser(UserDto input);

        Task<Result> UpdateUser(UserDto input);

        Task<UserDto> GetUser(string  id);

        IEnumerable<UserDto> GetAll(QueryUserFilter filter);
        Task<IEnumerable<UserDto>> GetAllByAsync(QueryUserFilter filter);

        Task<Result> Delete(string id);

        Task<Result> SetRole(string userId, string roleId);
        Task<Result> Login(string name, string password);
    }
}
