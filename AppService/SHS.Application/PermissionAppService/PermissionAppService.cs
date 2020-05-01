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
            return await _permissionService.Add(_mapper.Map<Permission>(dto));
        }

        public async Task<Result> Delete(string id, string userId)
        {
            return await _permissionService.Delete(id, userId);
        }

        public async Task<Dtos.PermissionDto> Get(string id)
        {
            return _mapper.Map<Dtos.PermissionDto>(await _permissionService.Get(id));
        }

        public async Task<Base.PagedResultDto<Dtos.PermissionDto>> GetAll(QueryPermissionFilter filter)
        {
            var result = new Base.PagedResultDto<PermissionDto>();
            var permission = await _permissionService.GetAll(new Service.PermissionService.Dto.QueryPermissionFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
            });
            result.Items = _mapper.Map<List<PermissionDto>>(permission.Items);
            result.TotalCount = permission.TotalCount;
            return result;
        }

        public async Task<Result> Update(ModifyPermissionDto dto)
        {
            return await _permissionService.Update(_mapper.Map<Permission>(dto));
        }
    }
}
