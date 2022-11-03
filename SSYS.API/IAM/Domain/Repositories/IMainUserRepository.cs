using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Repositories;

public interface IMainUserRepository
{
    Task<IEnumerable<Account>> ListAsync();
    Task AddAsync(Account account);
    Task<Account> FindByIdAsync(int id);
    void Update(Account account);
    void Remove(Account account);
}