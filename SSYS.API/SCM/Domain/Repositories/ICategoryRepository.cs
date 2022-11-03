using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.SCM.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category category);
    Task<Category> FindByIdAsync(int id);
    void Update(Category category);
    void Remove(Category category);
    Task<IEnumerable<Category>> FindByCategoryTitleAsync(string title);
    Task<IEnumerable<Category>> ListByCategoryIdAsync(int id);
    Task<Category> FindByCategoryIdAsync(int id);
}