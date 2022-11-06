using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Services.Communication;

namespace SSYS.API.CRM.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> ListAsync(); 
    Task<CustomerResponse> SaveAsync(Customer customer);
    Task<CustomerResponse> UpdateAsync(int id, Customer customer);
    Task<CustomerResponse> DeleteAsync(int id);
}