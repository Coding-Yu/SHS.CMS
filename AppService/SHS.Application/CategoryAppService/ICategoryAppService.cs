using SHS.Application.CategoryAppService.Dtos;
using SHS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Application.CategoryAppService
{
    public interface ICategoryAppService
    {
        Task<Result> Add(AddCategoryDto category);
        Task<IEnumerable<CategoryDto>> GetAll(QueryCategoryFilter filter);
        Task<Result> Update(ModifyCategoryDto category);
        Task<CategoryDto> Get(string id);
        Task<Result> Delete(string id);
    }
}
