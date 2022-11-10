using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;

namespace SSYS.API.IAM.Domain.Repositories;

public interface IAccountRespository
{
    Task<IEnumerable<Account?>> ListAsync();
    Task AddAsync(Account? account);
    Task<Account?> FindByIdAsync(int id);
    void Update(Account? account);
    void Remove(Account? account);
}