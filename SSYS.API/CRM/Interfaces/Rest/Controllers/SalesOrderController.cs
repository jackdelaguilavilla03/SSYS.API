using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Services;
using SSYS.API.CRM.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace SSYS.API.CRM.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete SalesOrder")]
public class SalesOrderController
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
    
}