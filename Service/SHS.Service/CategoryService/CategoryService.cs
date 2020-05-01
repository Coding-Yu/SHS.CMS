using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Categorys;
using SHS.Domain.Repository.Interfaces;
using SHS.Service.CategoryService.Dto;
using SHS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHS.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IRepository<Category> categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<Result> Add(Category category)
        {
            try
            {
                if (category != null)
                {
                    await _categoryRepository.AddByAsync(category);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("分类添加异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Result> Delete(string id, string userId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var category = await _categoryRepository.GetByAsync(id);
                    if (category != null)
                    {
                        category.DeleteUserId = Guid.Parse(userId);
                        category.DeleteDate = DateTime.Now;
                        category.IsDel = 1;
                        await _categoryRepository.RemoveByAsync(category);
                        return Result.Success(200);
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("分类删除异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Category> Get(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return await _categoryRepository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("分类获取异常" + ex.ToString());
                return null;
            }
        }

        public async Task<PagedResultDto<Category>> GetAll(QueryCategoryFilter filter)
        {
            var result = new PagedResultDto<Category>();
            try
            {
                var query = await _categoryRepository.GetAllByAsync();
                query = query.Where(x => x.IsDel == 0);
                if (!string.IsNullOrWhiteSpace(filter.name))
                {
                    query = query.Where(x => x.Name.Contains(filter.name));
                }
                result.TotalCount = query.Count();
                result.Items = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("文章获取异常" + ex.ToString());
            }
            return result;
        }

        public async Task<Result> Update(Category category)
        {
            try
            {
                if (category != null)
                {
                    category.UpdateDate = DateTime.Now;
                    await _categoryRepository.UpdateByAsync(category);
                    return Result.Success();
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("分类更新异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }
    }
}
