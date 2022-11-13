namespace SSYS.API.Profile.Domain.Repositories;

public interface IProfileRepository
{
    Task<IEnumerable<Model.Entities.Profile>> ListAsync();
    Task AddAsync(Model.Entities.Profile profile);
    Task<Model.Entities.Profile> FindByIdAsync(int id);
    void Update(Model.Entities.Profile profile);
    void Remove(Model.Entities.Profile profile);
}