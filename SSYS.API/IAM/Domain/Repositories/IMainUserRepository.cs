using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Repositories;

public interface IMainUserRepository
{
    Task<IEnumerable<MainUser>> ListAsync();
    Task AddAsync(MainUser mainUser);
    Task<MainUser> FindByIdAsync(int id);
    void Update(MainUser mainUser);
    void Remove(MainUser mainUser);
}