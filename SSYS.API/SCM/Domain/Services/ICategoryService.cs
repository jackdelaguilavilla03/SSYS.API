using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
<<<<<<< Updated upstream
    //Task<IEnumerable<Category>> ListByCategoryIdAsync(int id);
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int categoryId, Category category);
    Task<CategoryResponse> DeleteAsync(int categoryId);
    Task<IEnumerable<Category>> FindByCategoryTitleAsync(string title);
    //Task<IEnumerable<Category>> FindByCategoryIdAsync(int id);
=======
    Task<Category> FindByCategoryIdAsync(int id);
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int categoryId, Category category);
    Task<CategoryResponse> DeleteAsync(int categoryId);
>>>>>>> Stashed changes
}