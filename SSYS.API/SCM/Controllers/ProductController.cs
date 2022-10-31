using Microsoft.AspNetCore.Mvc;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services;

namespace SSYS.API.SCM.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductController:ControllerBase
{
   private readonly IProductService _productService;

   public ProductController(IProductService productService)
   {
      _productService = productService;
   }
   
   [HttpGet]
   public async Task<IEnumerable<Product>> GetAllAsync()
   {
      var  product= await _productService.ListAsync();
      return product;
   }
}