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
        public async Task<Result> AddAsync(RoleDto dto)
        {
            Rolepermission role = new Rolepermission();
            role.Name = dto.Name;
            role.Summary = dto.Summary;
            role.IsDefault = dto.isDefault;
            role.Remarks = dto.Remarks;
            role.CreateDate = dto.CreateDate;
            role.CreateUserId = dto.CreateUserId;
            return await _roleService.Add(role);
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
                name = filter.Name,
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
            });
            foreach (var item in roles)
            {
                result.Add(new RoleDto()
                {
                    CreateDate = item.CreateDate,
                    CreateUserId = item.CreateUserId,
                    ID = item.ID.ToString().ToUpper(),
                    isDefault = item.IsDefault,
                    Name = item.Name,
                    Remarks = item.Remarks,
                    Summary=item.Summary,
                    IsDel = item.IsDel,
                });
            }
            return result;
        }

        public async Task<Result> RoleGivePermission(string roleid, IList<string> permissionIds)
        {
            return await _roleService.RoleGivePermission(roleid, permissionIds);
        }

        public async Task<Result> Update(RoleDto dto)
        {
            Rolepermission role = new Rolepermission();
            role.ID = Guid.Parse(dto.ID);
            role.Name = dto.Name;
            role.Summary = dto.Summary;
            role.IsDefault = dto.isDefault;
            role.Remarks = dto.Remarks;
            role.UpdateDate = dto.CreateDate;
            // role.UpdateUserId =Guid.Parse(dto.UpdateUserId.ToString());
            return await _roleService.Update(_mapper.Map<Rolepermission>(role));
        }
        public async Task<IList<Permission>> GetPermissionByRoleId(string id) {
            return await _roleService.GetPermissionByRoleId(id);
        }
    }
}
