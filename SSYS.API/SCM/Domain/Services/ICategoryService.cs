using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
    Task<IEnumerable<Category>> ListByCategoryIdAsync(int product);
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int categoryId, Category category);
    Task<CategoryResponse> DeleteAsync(int categoryId); 
}