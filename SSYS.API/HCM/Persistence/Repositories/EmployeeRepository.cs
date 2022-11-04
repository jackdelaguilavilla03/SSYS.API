using SSYS.API.HCM.Domain.Models;
using SSYS.API.HCM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.HCM.Persistence.Repositories;

public class EmployeeRepository : BaseRepository, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<Employee>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public Task<Employee> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Employee employee)
    {
        throw new NotImplementedException();
    }

    public void Remove(Employee employee)
    {
        _context.Employees.Remove(employee);
    }
}