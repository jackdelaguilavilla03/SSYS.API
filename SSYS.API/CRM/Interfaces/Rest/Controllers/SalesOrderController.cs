using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Services;
using SSYS.API.CRM.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace SSYS.API.CRM.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete SalesOrder")]
public class SalesOrderController : ControllerBase
{
    private readonly ISaleOrderService _saleOrderService;
    private readonly IMapper _mapper;


    public SalesOrderController(ISaleOrderService saleOrderService, IMapper mapper)
    {
        _saleOrderService = saleOrderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SaleOrderResource>> GetAllAsync()
    {
        var salesOrder = await _saleOrderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<SaleOrder>, IEnumerable<SaleOrderResource>>(salesOrder);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSaleOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var saleOrder = _mapper.Map<SaveSaleOrderResource, SaleOrder>(resource);

        var result = await _saleOrderService.SaveAsync(saleOrder);

        if (!result.Success)
            return BadRequest(result.Message);

        var saleOrderResource = _mapper.Map<SaleOrder, SaleOrderResource>(result.Resource);

        return Created(nameof(PostAsync), saleOrderResource);
    }

}