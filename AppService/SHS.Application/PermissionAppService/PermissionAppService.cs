using AutoMapper;
using SHS.Application.PermissionAppService.Dtos;
using SHS.Domain.Core.Permissions;
using SHS.Service.Interfaces;
using SHS.Service.PermissionService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Application.PermissionAppService
{
    public class PermissionAppService : IPermissionAppService
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        public PermissionAppService(IPermissionService permissionService, IMapper mapper)
        {
            _mapper = mapper;
            _permissionService = permissionService;
        }
        public async Task<Result> Add(AddPermissionDto dto)
        {
            Permission permission = new Permission();
            permission.Name = dto.Name;
            permission.Path = dto.Path;
            permission.CreateDate = dto.CreateDate;
            permission.CreateUserId = dto.CreateUserId;
            permission.Remarks = dto.Remarks;
            return await _permissionService.Add(permission);
        }

        public async Task<Result> Delete(string id)
        {
            return await _permissionService.Delete(id);
        }

        public async Task<Dtos.PermissionDto> Get(string id)
        {
            return _mapper.Map<Dtos.PermissionDto>(await _permissionService.Get(id));
        }

        public async Task<IEnumerable<Dtos.PermissionDto>> GetAll(QueryPermissionFilter filter)
        {
            var result = new List<PermissionDto>();
            var permission = await _permissionService.GetAll(new Service.PermissionService.Dto.QueryPermissionFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
            });
            foreach (var item in permission)
            {
                result.Add(new PermissionDto()
                {
                    ID = item.ID.ToString(),
                    name = item.Name,
                    path = item.Path,
                    UpdateDate = item.UpdateDate,
                    UpdateUserId = item.UpdateUserId,
                    CreateDate = item.CreateDate,
                    CreateUserId = item.CreateUserId,
                    Remarks = item.Remarks,
                });
            }
            return result;
        }

        public async Task<Result> Update(ModifyPermissionDto dto)
        {
            Permission permission = new Permission();
            permission.ID = Guid.Parse(dto.ID);
            permission.Name = dto.Name;
            permission.Path = dto.Path;
            permission.UpdateDate = dto.UpdateDate;
            permission.UpdateUserId = Guid.Parse(dto.UpdateUserId.ToString());
            permission.Remarks = dto.Remarks;
            return await _permissionService.Update(_mapper.Map<Permission>(dto));
        }
    }
}
