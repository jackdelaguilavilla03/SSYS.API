﻿using System.Net.Mime;
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
[SwaggerTag("Create, read, update and delete Customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    
    public CustomersController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);

        var result = await _customerService.SaveAsync(customer);

        if (!result.Success)
            return BadRequest(result.Message);

        var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

        return Created(nameof(PostAsync), customerResource);
    }


}