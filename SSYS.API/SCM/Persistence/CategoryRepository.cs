﻿using Microsoft.EntityFrameworkCore;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.SCM.Persistence;

public class CategoryRepository: BaseRepository, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
<<<<<<< Updated upstream
=======
        
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            .Include(c => c.Title)
            .FirstOrDefaultAsync(c => c.Id == id);
=======
            .Include(p => p.Title)
            .FirstOrDefaultAsync(p => p.Id == id);
>>>>>>> Stashed changes
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }

    public void Remove(Category category)
    {
        _context.Categories.Remove(category);
    }

<<<<<<< Updated upstream
    public async Task<IEnumerable<Category>> FindByCategoryTitleAsync(string title)
    {
        return await _context.Categories
            .Where(c => c.Title == title)
            .Include(c => c.Title)
            .ToListAsync();
    }

    //public Task<IEnumerable<Category>> ListByCategoryIdAsync(int id)
//    {
  //      throw new NotImplementedException();
    //}

//    public async Task<Category> FindByCategoryIdAsync(int id)
  //  {
    //    return await _context.Categories.FindAsync(id);
//    }
=======
    public async Task<Category> FindByCategoryTitleAsync(string title)
    {
        return await _context.Categories
            .Include(p => p.Title)
            .FirstOrDefaultAsync(p => p.Title == title);
    }
>>>>>>> Stashed changes
}