using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.SCM.Domain.Repositories;

public interface IPurchaseOrderRepository
{
    Task<IEnumerable<PurchaseOrder>> ListAsync();
    Task AddAsync(PurchaseOrder purchaseOrder);
    Task<PurchaseOrder> FindByIdAsync(int id);
    void Update(PurchaseOrder purchaseOrder);
    void Remove(PurchaseOrder purchaseOrder);
    Task<IEnumerable<PurchaseOrder>> FindByPurchaseOrderDateTime(DateTime start, DateTime end);
    Task<IEnumerable<PurchaseOrder>> FindByPurchaseOrderSupplierId(int supplierId);
}