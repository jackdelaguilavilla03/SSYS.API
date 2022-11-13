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
        throw new NotImplementedException();
    }

    public async Task AddAsync(Domain.Model.Entities.Profile profile)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Entities.Profile> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Model.Entities.Profile profile)
    {
        throw new NotImplementedException();
    }

    public void Remove(Domain.Model.Entities.Profile profile)
    {
        throw new NotImplementedException();
    }
}