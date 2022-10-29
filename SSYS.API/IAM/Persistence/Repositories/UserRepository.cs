using Microsoft.EntityFrameworkCore;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.IAM.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByUserNameAsync(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task<IEnumerable<User>> FindByMainUserIdAsync(int mainUserId)
    {
        return await _context.Users.Where(u => u.MainUserId == mainUserId).ToListAsync();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public bool ExistsByUser(string requestUsername)
    {
        return _context.Users.Any(u => u.UserName == requestUsername);
    }

    public User FindById(int id)
    {
        return _context.Users.Find(id);
    }
}