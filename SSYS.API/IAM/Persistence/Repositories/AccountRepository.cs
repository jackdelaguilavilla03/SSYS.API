using Microsoft.EntityFrameworkCore;
using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.IAM.Persistence.Repositories;

public class AccountRepository: BaseRepository, IAccountRespository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Account?>> ListAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task AddAsync(Account? account)
    {
        if (account != null) await _context.Accounts.AddAsync(account);
    }

    public async Task<Account?> FindByIdAsync(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public void Update(Account? account)
    {
        if (account != null) _context.Accounts.Update(account);
    }

    public void Remove(Account? account)
    {
        _context.Accounts.Remove(account);
    }
}