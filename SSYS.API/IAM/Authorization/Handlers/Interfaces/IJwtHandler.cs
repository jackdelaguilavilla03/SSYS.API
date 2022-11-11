using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;

namespace SSYS.API.IAM.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}