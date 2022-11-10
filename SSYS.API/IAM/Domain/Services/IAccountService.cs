using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Services.Communication;

namespace SSYS.API.IAM.Domain.Services;

public interface IAccountService
{
    Task<IEnumerable<Account?>> ListAsync();
    Task<Account?> GetByIdAsync(int id);
    Task RegisterAsync();
    Task UpdateAsync(int id);
    Task DeleteAsync(int id);
}