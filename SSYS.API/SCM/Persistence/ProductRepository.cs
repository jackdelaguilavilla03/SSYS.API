using Microsoft.EntityFrameworkCore;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.SCM.Persistence;

public class ProductRepository: BaseRepository, IProductRepository
{


    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    
    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }

    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}