using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByUserNameAsync(string userName);
    Task<IEnumerable<User>> FindByMainUserIdAsync(int mainUserId);
    void Update(User user);
    void Remove(User user);
    bool ExistsByUser(string requestUsername);
    User FindById(int id);
}