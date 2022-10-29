using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}