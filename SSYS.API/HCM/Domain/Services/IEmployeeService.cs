using SSYS.API.HCM.Domain.Models;
using SSYS.API.HCM.Domain.Services.Communication;

namespace SSYS.API.HCM.Domain.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> ListAsync(); 
    Task<EmployeeResponse> SaveAsync(Employee employee);
    Task<EmployeeResponse> UpdateAsync(int id, Employee employee);
    Task<EmployeeResponse> DeleteAsync(int id);
}