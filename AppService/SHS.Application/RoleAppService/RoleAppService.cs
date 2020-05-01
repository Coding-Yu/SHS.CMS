using AutoMapper;
using SHS.Application.RoleAppService.Dtos;
using SHS.Application.UserAppService.Dtos;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Infra.Data.Users;
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
        public async Task<Result> AddAsync(AddRoleDto dto)
        {
            return await _roleService.Add(_mapper.Map<Rolepermission>(dto));
        }

        public async Task<Result> Delete(string id,string userId)
        {
            return await _roleService.Delete(id,userId);
        }

        public async Task<RoleDto> Get(string id)
        {
            return _mapper.Map<RoleDto>(await _roleService.Get(id));
        }

        public async Task<Base.PagedResultDto<RoleDto>> GetAll(QueryRoleFilter filter)
        {
            var result = new Base.PagedResultDto<RoleDto>();
            var roles = await _roleService.GetAll(new Service.RoleService.Dto.QueryRoleFilter()
            {
                name = filter.Name,
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
            });
            result.Items = _mapper.Map<List<RoleDto>>(roles.Items);
            result.TotalCount = roles.TotalCount;
            return result;
        }

        public async Task<Result> RoleGivePermission(string roleid, IList<string> permissionIds)
        {
            return await _roleService.RoleGivePermission(roleid, permissionIds);
        }

        public async Task<Result> Update(ModifyRoleDto dto)
        {
            return await _roleService.Update(_mapper.Map<Rolepermission>(dto));
        }
        public async Task<IList<Permission>> GetPermissionByRoleId(string id)
        {
            return await _roleService.GetPermissionByRoleId(id);
        }
    }
}
