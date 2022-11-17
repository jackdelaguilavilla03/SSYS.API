using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services;

public interface IPurchaseOrder
{
    Task<IEnumerable<PurchaseOrder>> ListAsync();
    Task<IEnumerable<PurchaseOrder>> ListByPurchaseOrderIdAsync(int id);
    Task<PurchaseOrderResponse> SaveAsync(PurchaseOrder purchaseOrder);
    Task<PurchaseOrderResponse> UpdateAsync(int purchaseOrderId, PurchaseOrder purchaseOrder);
    Task<PurchaseOrderResponse> DeleteAsync(int purchaseOrderId);
}