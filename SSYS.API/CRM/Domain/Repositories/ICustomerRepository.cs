using SSYS.API.CRM.Domain.Models;

namespace SSYS.API.CRM.Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> ListAsync();
    Task AddAsync(Customer customer);
    Task<Customer> FindByIdAsync(int id);
    void Update(Customer customer);
    void Remove(Customer customer);
}