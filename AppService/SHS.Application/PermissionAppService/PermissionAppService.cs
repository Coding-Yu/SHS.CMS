using AutoMapper;
using SHS.Application.PermissionAppService.Dtos;
using SHS.Domain.Core.Permissions;
using SHS.Service.Interfaces;
using SHS.Service.PermissionService;
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
        public async Task<Result> Add(PermiisionDto permission)
        {
            return await _permissionService.Add(_mapper.Map<Permission>(permission));
        }

        public async Task<Result> Delete(string id)
        {
            return await _permissionService.Delete(id);
        }

        public async Task<PermiisionDto> Get(string id)
        {
            return _mapper.Map<PermiisionDto>(await _permissionService.Get(id));
        }

        public async Task<IEnumerable<PermiisionDto>> GetAll(QueryPermissionFilter filter)
        {
            var result = new List<PermiisionDto>();
            var permission = await _permissionService.GetAll(new Service.PermissionService.Dto.QueryPermissionFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                PageNum = filter.PageNum,
                PageSize = filter.PageSize,
                Sort = filter.Sort,
            });
            foreach (var item in permission)
            {
                result.Add(_mapper.Map<PermiisionDto>(item));
            }
            return result;
        }

        public async Task<Result> Update(PermiisionDto permiision)
        {
            return await _permissionService.Update(_mapper.Map<Permission>(permiision));
        }
    }
}
