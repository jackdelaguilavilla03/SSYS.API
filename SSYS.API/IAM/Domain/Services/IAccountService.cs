using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Services.Communication;

namespace SSYS.API.IAM.Domain.Services;

public interface IAccountService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<Account>> ListAsync();
    Task<Account> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(int id, UpdateRequest request);
    Task DeleteAsync(int id);
}