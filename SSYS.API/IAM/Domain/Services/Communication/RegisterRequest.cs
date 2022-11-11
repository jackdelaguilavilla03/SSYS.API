using System.ComponentModel.DataAnnotations;
using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class RegisterRequest
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}