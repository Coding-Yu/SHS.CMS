using SHS.Domain.Core.Categorys;
using SHS.Service.CategoryService.Dto;
using SHS.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHS.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Result> Add(Category category);
        Task<IEnumerable<Category>> GetAll(QueryCategoryFilter filter);
        Task<Result> Update(Category category);
        Task<Category> Get(string id);
        Task<Result> Delete(string id);
    }
}
