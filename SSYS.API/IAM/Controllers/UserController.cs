using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSYS.API.IAM.Domain.Services;
using SSYS.API.IAM.Domain.Services.Communication;

namespace SSYS.API.IAM.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sing-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("sing-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "Update successful" });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "Delete successful" });
    }
}