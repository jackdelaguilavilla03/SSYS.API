namespace SSYS.API.Profile.Domain.Model.Repositories;

public interface IProfileRepository
{
    Task<IEnumerable<Entities.Profile>> ListAsync();
    Task AddAsync(Entities.Profile profile);
    Task<Entities.Profile> FindByIdAsync(int id);
    void Update(Entities.Profile profile);
    void Remove(Entities.Profile profile);
}