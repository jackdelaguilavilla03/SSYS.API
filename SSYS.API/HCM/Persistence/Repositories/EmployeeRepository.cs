using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Employee>> ListAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public async Task<Employee> FindByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
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