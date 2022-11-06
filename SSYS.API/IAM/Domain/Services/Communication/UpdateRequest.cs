using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class UpdateRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}