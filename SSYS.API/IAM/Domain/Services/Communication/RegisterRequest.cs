using System.ComponentModel.DataAnnotations;
using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class RegisterRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }

}