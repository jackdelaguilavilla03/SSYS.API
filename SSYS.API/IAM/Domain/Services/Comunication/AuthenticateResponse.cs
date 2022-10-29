using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Services.Comunication;

public class AuthenticateResponse : BaseModel
{
    public string Username { get; set; }
    public string Token { get; set; }
}