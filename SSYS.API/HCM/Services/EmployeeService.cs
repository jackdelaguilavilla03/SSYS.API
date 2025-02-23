﻿using SSYS.API.HCM.Domain.Models;
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

    public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
    {
        var existingEmployee = await _employeeRepository.FindByIdAsync(id);

        if (existingEmployee == null)
            return new EmployeeResponse("Employee not found.");

        existingEmployee.Name = employee.Name;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Phone = employee.Phone;

        try
        {
            _employeeRepository.Update(existingEmployee);
            await _unitOfWork.CompleteAsync();

            return new EmployeeResponse(existingEmployee);
        }
        catch (Exception e)
        {
            return new EmployeeResponse($"An error occurred while updating the employee: {e.Message}");
        }
    }

    public async Task<EmployeeResponse> DeleteAsync(int id)
    {
        var existingEmployee = await _employeeRepository.FindByIdAsync(id);

        if (existingEmployee == null)
            return new EmployeeResponse("Employee not found.");

        try
        {
            _employeeRepository.Remove(existingEmployee);
            await _unitOfWork.CompleteAsync();

            return new EmployeeResponse(existingEmployee);
        }
        catch (Exception e)
        {
            return new EmployeeResponse($"An error occurred while deleting the employee: {e.Message}");
        }
    }
}