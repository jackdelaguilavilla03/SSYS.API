using System.ComponentModel.DataAnnotations;

namespace SSYS.API.IAM.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    public string Email { get; set; }
}