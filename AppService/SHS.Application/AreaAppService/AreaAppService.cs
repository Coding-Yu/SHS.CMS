using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SHS.Application.AreaAppService.Dtos;
using SHS.Application.Base;
using SHS.Domain.Core.Area;
using SHS.Service.AreaService;
using SHS.Service.Interfaces;

namespace SHS.Application.AreaAppService
{
    public class AreaAppService : IAreaAppService
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;
        public AreaAppService(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }
        public async Task<Result> Add(AddAreaDto dto)
        {
            return await _areaService.Add(_mapper.Map<Area>(dto));
        }

        public async Task<Result> Delete(string id, string userId)
        {
            return await _areaService.Delete(id, userId);
        }

        public async Task<AreaDto> Get(string id)
        {
            var entity = await _areaService.Get(id);
            var result = _mapper.Map<AreaDto>(entity);
            return result;
        }

        public async Task<Base.PagedResultDto<AreaDto>> GetAll(QueryAreaFilter filter)
        {
            var result = new Base.PagedResultDto<AreaDto>();
            var areas = await _areaService.GetAll(new Service.AreaService.Dto.QueryAreaFilter()
            {
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
                ZipCode = filter.ZipCode,
                City = filter.City,
                State = filter.State,
                Street = filter.Street
            });

            result.Items = _mapper.Map<List<AreaDto>>(areas.Items);
            result.TotalCount = areas.TotalCount;
            return result;
        }

        public async Task<Result> Update(ModifyAreaDto dto)
        {
            return await _areaService.Update(_mapper.Map<Area>(dto));
        }
    }
}
