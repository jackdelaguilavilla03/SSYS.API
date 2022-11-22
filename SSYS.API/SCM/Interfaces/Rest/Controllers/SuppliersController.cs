using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SuppliersController:ControllerBase
{
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;

    public SuppliersController(ISupplierService supplierService, IMapper mapper)
    {
        _supplierService = supplierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SupplierResource>> GetAllAsync()
    {
        var supplier = await _supplierService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(supplier);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupplierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);//error

        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
        var result = await _supplierService.SaveAsync(supplier);

        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Created(nameof(PostAsync), supplierResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupplierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);//error
        
        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
        var result = await _supplierService.UpdateAsync(id,supplier);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Ok(supplierResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _supplierService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Ok(supplierResource);
    }
}