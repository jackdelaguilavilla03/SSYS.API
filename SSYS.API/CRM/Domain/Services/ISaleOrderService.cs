using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Services.Communication;

namespace SSYS.API.CRM.Domain.Services;

public interface ISaleOrderService
{
    Task<IEnumerable<SaleOrder>> ListAsync(); 
    Task<SaleOrderResponse> SaveAsync(SaleOrder saleOrder);
    Task<SaleOrderResponse> UpdateAsync(int id, SaleOrder saleOrder);
    Task<SaleOrderResponse> DeleteAsync(int id);
}