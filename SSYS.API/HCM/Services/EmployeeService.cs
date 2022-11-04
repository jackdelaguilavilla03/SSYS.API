using SSYS.API.HCM.Domain.Models;
using SSYS.API.HCM.Domain.Repositories;
using SSYS.API.HCM.Domain.Services;
using SSYS.API.HCM.Domain.Services.Communication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.HCM.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Employee>> ListAsync()
    {
        return await _employeeRepository.ListAsync();
    }

    public async Task<EmployeeResponse> SaveAsync(Employee employee)
    {
        try
        {
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.CompleteAsync();

            return new EmployeeResponse(employee);
        }
        catch (Exception e)
        {
            return new EmployeeResponse($"A error went while adding employee: {e.Message}");
        }
    }

    public Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeResponse> DeleteAsync(int id)
    {
        var existingCategory = await _employeeRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new EmployeeResponse("Category not found.");

        try
        {
            _employeeRepository.Remove(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new EmployeeResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new EmployeeResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}