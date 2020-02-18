using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Tags;
using SHS.Domain.Repository.Interfaces;
using SHS.Service.Interfaces;
using SHS.Service.TagService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHS.Service.TagService
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _tagRepository;
        private readonly ILogger<TagService> _logger;

        public TagService(IRepository<Tag> tagRepository, ILogger<TagService> logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }
        public async Task<Result> Add(Tag tag)
        {
            try
            {
                if (tag != null)
                {
                    await _tagRepository.AddByAsync(tag);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("标签添加异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Result> Delete(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var tag = await _tagRepository.GetByAsync(id);
                    if (tag != null)
                    {
                        await _tagRepository.RemoveByAsync(tag);
                        return Result.Success(200);
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("标签删除异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Tag> Get(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return await _tagRepository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("标签获取异常" + ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Tag>> GetAll(QueryTagFilter filter)
        {
            var result = new List<Tag>();
            try
            {
                var query = await _tagRepository.GetAllByAsync();
                if (!string.IsNullOrWhiteSpace(filter.name))
                {
                    query = query.Where(x => x.Name.Contains(filter.name));
                }
                result = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("标签获取异常" + ex.ToString());
            }
            return result;
        }

        public async Task<Result> Update(Tag tag)
        {
            try
            {
                if (tag != null)
                {
                    await _tagRepository.UpdateByAsync(tag);
                    return Result.Success();
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("标签更新异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }
    }
}
