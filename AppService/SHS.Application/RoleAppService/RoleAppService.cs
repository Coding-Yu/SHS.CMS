using AutoMapper;
using SHS.Application.RoleAppService.Dtos;
using SHS.Domain.Core.Roles;
using SHS.Service.Interfaces;
using SHS.Service.RoleService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.RoleAppService
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleService _roleService;
        public readonly IMapper _mapper;
        public RoleAppService(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        public async Task<Result> AddAsync(RoleDto role)
        {
            return await _roleService.Add(_mapper.Map<Role>(role));
        }

        public async Task<Result> Delete(string id)
        {
            return await _roleService.Delete(id);
        }

        public async Task<RoleDto> Get(string id)
        {
            return _mapper.Map<RoleDto>(await _roleService.Get(id));
        }

        public async Task<IEnumerable<RoleDto>> GetAll(QueryRoleFilter filter)
        {
            var result = new List<RoleDto>();
            var roles = await _roleService.GetAll(new Service.RoleService.Dto.QueryRoleFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                PageNum = filter.PageNum,
                PageSize = filter.PageSize,
                Sort = filter.Sort,
            });
            foreach (var item in roles)
            {
                result.Add(_mapper.Map<RoleDto>(item));
            }
            return result;
        }

        public async Task<Result> RoleGivePermission(string roleid, List<string> permissionIds)
        {
            return await _roleService.RoleGivePermission(roleid, permissionIds);
        }

        public async Task<Result> Update(RoleDto role)
        {
            return await _roleService.Update(_mapper.Map<Role>(role));
        }
    }
}
