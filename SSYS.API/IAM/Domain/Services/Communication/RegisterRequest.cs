using System.ComponentModel.DataAnnotations;
using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class RegisterRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public User.Status UserStatus { get; set; }
    [Required] public int AccountId { get; set; }
    [Required] public Account Account { get; set; }
    [Required] public User.Role UserRoles { get; set; }

}