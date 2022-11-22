using Microsoft.EntityFrameworkCore;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.SCM.Persistence;

public class SupplierRepository: BaseRepository, ISupplierRepository
{
    public SupplierRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _context.Suppliers
            .Include(s => s.Name)
            .ToListAsync();
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
    }

    public async Task<Supplier> FindByIdAsync(int id)
    {
        return await _context.Suppliers
            .Include(s => s.Name)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public void Update(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
    }

    public void Remove(Supplier supplier)
    {
        _context.Suppliers.Remove(supplier);
    }

    public async Task<Supplier> FindBySupplierRuc(int ruc)
    {
        return await _context.Suppliers
            .Include(s => s.Name)
            .FirstOrDefaultAsync(s => s.Ruc == ruc);
    }

    public async Task<Supplier> FindBySupplierName(string name)
    {
        return await _context.Suppliers
            .Include(s => s.Name)
            .FirstOrDefaultAsync(s => s.Name == name);
    }
}