using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public class UpdateRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}