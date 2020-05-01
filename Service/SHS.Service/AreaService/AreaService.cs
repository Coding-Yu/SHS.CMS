using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Area;
using SHS.Domain.Repository.Interfaces;
using SHS.Service.AreaService.Dto;
using SHS.Service.Interfaces;

namespace SHS.Service.AreaService
{
    public class AreaService : IAreaService
    {
        private readonly IRepository<Area> _areaRepository;
        private readonly ILogger<AreaService> _logger;
        public AreaService(IRepository<Area> areaRepository, ILogger<AreaService> logger)
        {
            _areaRepository = areaRepository;
            _logger = logger;
        }
        public async Task<Result> Add(Area area)
        {
            try
            {
                if (area != null)
                {
                    await _areaRepository.AddByAsync(area);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("区域添加异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Result> Delete(string id, string userId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(userId))
                {
                    var area = await _areaRepository.GetByAsync(id);
                    if (area != null)
                    {
                        area.DeleteDate = DateTime.Now;
                        area.IsDel = 1;
                        area.DeleteUserId = Guid.Parse(userId);
                        await _areaRepository.RemoveByAsync(area);
                        return Result.Success(200);
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("区域删除异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Area> Get(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return await _areaRepository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("区域获取异常" + ex.ToString());
                return null;
            }
        }

        public async Task<PagedResultDto<Area>> GetAll(QueryAreaFilter filter)
        {
            var result = new PagedResultDto<Area>();
            try
            {
                var query = await _areaRepository.GetAllByAsync();
                query = query.Where(x => x.IsDel == 0);
                if (!string.IsNullOrWhiteSpace(filter.ZipCode))
                {
                    query = query.Where(x => x.ZipCode.Contains(filter.ZipCode));
                }
                result.Items = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
                result.TotalCount = query.Count();
            }
            catch (Exception ex)
            {
                _logger.LogError("文章获取异常" + ex.ToString());
            }
            return result;
        }

        public async Task<Result> Update(Area area)
        {
            try
            {
                if (area != null)
                {
                    area.UpdateDate = DateTime.Now;
                    await _areaRepository.UpdateByAsync(area);
                    return Result.Success();
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("文章更新异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }
    }
}
