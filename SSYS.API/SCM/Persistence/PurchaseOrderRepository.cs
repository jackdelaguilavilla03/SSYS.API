using Microsoft.EntityFrameworkCore;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.SCM.Persistence;

public class PurchaseOrderRepository:BaseRepository, IPurchaseOrderRepository
{
    public PurchaseOrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PurchaseOrder>> ListAsync()
    {
        return await _context.PurchaseOrders.ToListAsync();
    }

    public async Task AddAsync(PurchaseOrder purchaseOrder)
    {
        await _context.PurchaseOrders.AddAsync(purchaseOrder);
    }

    public async Task<PurchaseOrder> FindByIdAsync(int id)
    {
        return await _context.PurchaseOrders.FindAsync(id);
    }

    public void Update(PurchaseOrder purchaseOrder)
    {
        _context.PurchaseOrders.Update(purchaseOrder);
    }

    public void Remove(PurchaseOrder purchaseOrder)
    {
        _context.PurchaseOrders.Remove(purchaseOrder);
    }

    public async Task<IEnumerable<PurchaseOrder>> FindByPurchaseOrderDateTime(DateTime start, DateTime end)
    {
        return await _context.PurchaseOrders
            .Where(p => p.DateTime >= start && p.DateTime <= end)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<PurchaseOrder>> FindByPurchaseOrderSupplierId(int supplierId)
    {
        return await _context.PurchaseOrders
            .Where(p => p.SupplierId == supplierId)
            .ToListAsync();
    }
}