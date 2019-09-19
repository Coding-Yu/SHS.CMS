using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SHS.Application.CategoryAppService.Dtos;
using SHS.Domain.Core.Categorys;
using SHS.Service.CategoryService;
using SHS.Service.Interfaces;

namespace SHS.Application.CategoryAppService
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryAppService(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<Result> Add(CategoryDto category)
        {
            return await _categoryService.Add(_mapper.Map<Category>(category));
        }

        public async Task<Result> Delete(string id)
        {
            return await _categoryService.Delete(id);
        }

        public async Task<CategoryDto> Get(string id)
        {
            return _mapper.Map<CategoryDto>(await _categoryService.Get(id));
        }

        public async Task<IEnumerable<CategoryDto>> GetAll(QueryCategoryFilter filter)
        {
            var result = new List<CategoryDto>();
            var categorys = await _categoryService.GetAll(new Service.CategoryService.Dto.QueryCategoryFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                PageNum = filter.PageNum,
                PageSize = filter.PageSize,
                Sort = filter.Sort,
            });
            foreach (var item in categorys)
            {
                result.Add(_mapper.Map<CategoryDto>(item));
            }
            return result;
        }

        public async Task<Result> Update(CategoryDto category)
        {
            return await _categoryService.Update(_mapper.Map<Category>(category));
        }
    }
}
