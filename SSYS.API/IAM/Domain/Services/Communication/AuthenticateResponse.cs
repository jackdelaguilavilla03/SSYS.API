using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Services.Communication;

public class AuthenticateResponse : BaseModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}