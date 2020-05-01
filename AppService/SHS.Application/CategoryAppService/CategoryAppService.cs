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
        public async Task<Result> Add(AddCategoryDto dto)
        {
            return await _categoryService.Add(_mapper.Map<Category>(dto));
        }

        public async Task<Result> Delete(string id, string userId)
        {
            return await _categoryService.Delete(id,userId);
        }

        public async Task<CategoryDto> Get(string id)
        {
            return _mapper.Map<CategoryDto>(await _categoryService.Get(id));
        }

        public async Task<Base.PagedResultDto<CategoryDto>> GetAll(QueryCategoryFilter filter)
        {
            var result = new Base.PagedResultDto<CategoryDto>();
            var categorys = await _categoryService.GetAll(new Service.CategoryService.Dto.QueryCategoryFilter()
            {
                name = filter.name,
                PageCount = filter.PageCount,
                page = filter.page,
                limit = filter.limit,
                Sort = filter.Sort,
            });
            result.Items = _mapper.Map<List<CategoryDto>>(categorys.Items);
            result.TotalCount = categorys.TotalCount;
            return result;
        }

        public async Task<Result> Update(ModifyCategoryDto dto)
        {
            return await _categoryService.Update(_mapper.Map<Category>(dto));
        }
    }
}
