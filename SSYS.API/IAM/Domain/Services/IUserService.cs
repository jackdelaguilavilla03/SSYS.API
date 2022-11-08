using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Services.Communication;

namespace SSYS.API.IAM.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<User?>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(int id, UpdateRequest request);
    Task DeleteAsync(int id);
}