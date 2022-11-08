using Microsoft.EntityFrameworkCore;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.CRM.Persistence.Repositories;

public class SaleOrderRepository: BaseRepository, ISaleOrderRepository
{
    public SaleOrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SaleOrder>> ListAsync()
    {
        return await _context.SaleOrders.ToListAsync();
    }

    public async Task AddAsync(SaleOrder saleOrder)
    {
        await _context.SaleOrders.AddAsync(saleOrder);
    }

    public async Task<SaleOrder> FindByIdAsync(int id)
    {
        return await _context.SaleOrders.FindAsync(id);
    }

    public void Update(SaleOrder saleOrder)
    {
        _context.SaleOrders.Update(saleOrder);
    }

    public void Remove(SaleOrder saleOrder)
    {
        _context.SaleOrders.Remove(saleOrder);
    }
}