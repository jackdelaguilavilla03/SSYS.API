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
public class PurchaseOrdersController:ControllerBase
{
    private readonly IPurchaseOrderService _purchaseOrderService;
    private readonly IMapper _mapper;

    public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService, IMapper mapper)
    {
        _purchaseOrderService = purchaseOrderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PurchaseOrderResource>> GetAllAsync()
    {
        var purchaseOrder = await _purchaseOrderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderResource>>(purchaseOrder);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePurchaseOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);//error

        var purchaseOrder = _mapper.Map<SavePurchaseOrderResource, PurchaseOrder>(resource);
        var result = await _purchaseOrderService.SaveAsync(purchaseOrder);

        if (!result.Success)
            return BadRequest(result.Message);

        var purchaseOrderResource = _mapper.Map<PurchaseOrder, PurchaseOrderResource>(result.Resource);

        return Created(nameof(PostAsync), purchaseOrderResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePurchaseOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);//error
        
        var purchaseOrder = _mapper.Map<SavePurchaseOrderResource, PurchaseOrder>(resource);
        var result = await _purchaseOrderService.UpdateAsync(id,purchaseOrder);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var purchaseOrderResource = _mapper.Map<PurchaseOrder, PurchaseOrderResource>(result.Resource);

        return Ok(purchaseOrderResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _purchaseOrderService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var purchaseOrderResource = _mapper.Map<PurchaseOrder, PurchaseOrderResource>(result.Resource);

        return Ok(purchaseOrderResource);
    }
}