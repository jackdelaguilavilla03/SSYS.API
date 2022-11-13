using System.ComponentModel.DataAnnotations;

namespace SSYS.API.IAM.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
}