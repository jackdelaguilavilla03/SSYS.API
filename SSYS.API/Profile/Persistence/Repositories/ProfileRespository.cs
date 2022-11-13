using Microsoft.EntityFrameworkCore;
using SSYS.API.Profile.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

namespace SSYS.API.Profile.Persistence.Repositories;

public class ProfileRespository : BaseRepository, IProfileRepository
{
    public ProfileRespository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Model.Entities.Profile>> ListAsync()
    {
        return await _context.Profiles.ToListAsync();
    }

    public async Task AddAsync(Domain.Model.Entities.Profile profile)
    {
        await _context.Profiles.AddAsync(profile);
    }

    public async Task<Domain.Model.Entities.Profile> FindByIdAsync(int id)
    {
        return await _context.Profiles.FindAsync(id);
    }

    public void Update(Domain.Model.Entities.Profile profile)
    {
        _context.Profiles.Update(profile);
    }

    public void Remove(Domain.Model.Entities.Profile profile)
    {
        _context.Profiles.Remove(profile);
    }
}