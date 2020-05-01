using SHS.Infra.Data.Users;
using SHS.Service.Interfaces;
using SHS.Service.UsersService.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Service.UsersService
{
    public interface IUserService
    {
        Task<Result> Add(User user);
        IEnumerable<User> GetAll(QueryUserFilter filter);
        Task<PagedResultDto<User>> GetAllByAsync(QueryUserFilter filter);
        Task<Result> Update(User user);
        Task<User> Get(string id);
        Task<Result> Delete(string id,string userId);

        /// <summary>
        /// 给用户赋予角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<Result> UserGiveRole(string userId, string roleId);

        Task<User> GetUserInfo(string name, string password);
    }
}
