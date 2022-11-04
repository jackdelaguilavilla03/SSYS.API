using SSYS.API.HCM.Domain.Models;

namespace SSYS.API.HCM.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> ListAsync();
    Task AddAsync(Employee employee);
    Task<Employee> FindByIdAsync(int id);
    void Update(Employee employee);
    void Remove(Employee employee);
}