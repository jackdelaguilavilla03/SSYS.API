using SSYS.API.CRM.Domain.Models;

namespace SSYS.API.CRM.Domain.Repositories;

public interface ISaleOrderRepository
{
    Task<IEnumerable<SaleOrder>> ListAsync();
    Task AddAsync(SaleOrder saleOrder);
    Task<SaleOrder> FindByIdAsync(int id);
    void Update(SaleOrder saleOrder);
    void Remove(SaleOrder saleOrder);
}