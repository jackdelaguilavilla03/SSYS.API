using System.Data.Entity;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.SCM.Persistence;

public class ProductRepository: BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products
            .Include(p=>p.Title)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Title)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> FindByProductPriceAsync(int price)
    {
        return await _context.Products
            .Where(p=>p.Price==price)
            .Include(p=>p.Title)
            .ToListAsync();
    }
    
    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}