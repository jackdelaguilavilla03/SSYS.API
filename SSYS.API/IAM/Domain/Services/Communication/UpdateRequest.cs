using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class UpdateRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public User.Status UserStatus { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public User.Role UserRoles { get; set; }
}