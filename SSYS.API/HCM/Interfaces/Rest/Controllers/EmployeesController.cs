using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSYS.API.HCM.Domain.Models;
using SSYS.API.HCM.Domain.Services;
using SSYS.API.HCM.Resources;

namespace SSYS.API.HCM.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeesController(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<EmployeeResource>> GetAllAsync()
    {
        var categories = await _employeeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(categories);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = _mapper.Map<SaveEmployeeResource, Employee>(resource);

        var result = await _employeeService.SaveAsync(category);

        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);

        return Created(nameof(PostAsync), categoryResource);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployeeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = _mapper.Map<SaveEmployeeResource, Employee>(resource);

        var result = await _employeeService.UpdateAsync(id, category);

        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);

        return Ok(categoryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _employeeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);

        return Ok(categoryResource);
    }
    
}