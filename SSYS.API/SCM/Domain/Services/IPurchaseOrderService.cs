using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services;

public interface IPurchaseOrderService
{
    Task<IEnumerable<PurchaseOrder>> ListAsync();
    Task<IEnumerable<PurchaseOrder>> ListBySupplierIdAsync(int id);
    Task<PurchaseOrderResponse> SaveAsync(PurchaseOrder purchaseOrder);
    Task<PurchaseOrderResponse> UpdateAsync(int purchaseOrderId, PurchaseOrder purchaseOrder);
    Task<PurchaseOrderResponse> DeleteAsync(int purchaseOrderId);
}