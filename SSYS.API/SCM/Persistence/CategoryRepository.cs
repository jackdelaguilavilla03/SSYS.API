using Microsoft.EntityFrameworkCore;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.SCM.Persistence;

public class CategoryRepository: BaseRepository, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _context.Categories
            .Include(p => p.Title)
            .ToListAsync();
        
    }
    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }
    public async Task<Category> FindByIdAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.Title)
            .FirstOrDefaultAsync(c => c.Id == id);
    } 
    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }
    public void Remove(Category category)
    {
        _context.Categories.Remove(category);
    } 
    public async Task<IEnumerable<Category>> FindByCategoryTitleAsync(string title)
    {
        return await _context.Categories
            .Where(p => p.Title == title)
            .Include(c => c.Title)
            .ToListAsync();
    } 
    public async Task<IEnumerable<Category>> ListByCategoryIdAsync(int id)
    {
        return await _context.Categories
            .Where(p=>p.Id==id)
            .Include(p => p.Title)
            .ToListAsync();
    }
  

}