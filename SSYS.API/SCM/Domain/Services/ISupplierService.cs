using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task<IEnumerable<Supplier>> ListBySupplierIdAsync(int id);
    Task<SupplierResponse> SaveAsync(Supplier supplier);
    Task<SupplierResponse> UpdateAsync(int supplierId, Supplier supplier);
    Task<SupplierResponse> DeleteAsync(int supplierId);
}