using System.ComponentModel.DataAnnotations;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class AuthenticateRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}