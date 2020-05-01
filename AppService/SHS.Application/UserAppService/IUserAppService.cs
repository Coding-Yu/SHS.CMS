
using SHS.Application.UserAppService.Dtos;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.UserAppService
{
    public interface IUserAppService
    {
        Task<Result> AddUser(AddUserDto input);

        Task<Result> UpdateUser(ModifyUserDto input);

        Task<UserDto> GetUser(string  id);

        IEnumerable<UserDto> GetAll(QueryUserFilter filter);
        Task<Base.PagedResultDto<UserDto>> GetAllByAsync(QueryUserFilter filter);

        Task<Result> Delete(string id, string userId);

        Task<Result> SetRole(string userId, string roleId);
    }
}
