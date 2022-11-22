using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.SCM.Domain.Repositories;

public interface ISupplierRepository
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task AddAsync(Supplier supplier);
    Task<Supplier> FindByIdAsync(int id);
    void Update(Supplier supplier);
    void Remove(Supplier supplier);
    Task<Supplier> FindBySupplierRuc(int ruc);
    Task<Supplier> FindBySupplierName(string name);

}