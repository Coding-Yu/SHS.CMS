using AutoMapper;
using SHS.Application.UserAppService.Dtos;
using SHS.Infra.Data.Users;
using SHS.Service.Interfaces;
using SHS.Service.UsersService;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace SHS.Application.UserAppService
{
    public class UserAppService : IUserAppService
    {
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(GetType().GetTypeInfo().Assembly));
            var mapper = new Mapper(configuration);
            _mapper = mapper;
        }

        public async Task<Result> AddUser(UserDto input)
        {
            return await _userService.Add(_mapper.Map<User>(input));
        }

        public async Task<Result> Delete(string id)
        {
            return await _userService.Delete(id);
        }

        public IEnumerable<UserDto> GetAll(QueryUserFilter filter)
        {
            var result = new List<UserDto>();
            var users =  _userService.GetAll(new Service.UsersService.Dto.QueryUserFilter()
            {
                Email = filter.Email,
                Name = filter.Name,
                PageCount = filter.PageCount,
                PageNum = filter.PageNum,
                PageSize = filter.PageSize,
                Phone = filter.Phone,
                Sort = filter.Sort,
            });
            foreach (var item in users)
            {
                result.Add(_mapper.Map<UserDto>(item));
            }
            return result;
        }
        public async Task<IEnumerable<UserDto>> GetAllByAsync(QueryUserFilter filter)
        {
            var result = new List<UserDto>();
            var users = await _userService.GetAllByAsync(new Service.UsersService.Dto.QueryUserFilter()
            {
                Email = filter.Email,
                Name = filter.Name,
                PageCount = filter.PageCount,
                PageNum = filter.PageNum,
                PageSize = filter.PageSize,
                Phone = filter.Phone,
                Sort = filter.Sort,
            });
            foreach (var item in users)
            {
                result.Add(_mapper.Map<UserDto>(item));
            }
            return result;
        }
        public async Task<UserDto> GetUser(string id)
        {
            return _mapper.Map<UserDto>(await _userService.Get(id));
        }

        public async Task<Result> Login(string name, string password)
        {
            return await _userService.Login(name, password);
        }

        public async Task<Result> SetRole(string userId, string roleId)
        {
            return await _userService.UserGiveRole(userId, roleId);
        }

        public async Task<Result> UpdateUser(UserDto input)
        {
            return await _userService.Update(_mapper.Map<User>(input));
        }
    }
}
