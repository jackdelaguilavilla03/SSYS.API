using SSYS.API.Profile.Domain.Services.Communication;

namespace SSYS.API.Profile.Domain.Services;

public interface IProfileService
{
    Task<IEnumerable<Model.Entities.Profile>> ListAsync(); 
    Task<ProfileResponse> SaveAsync(Model.Entities.Profile profile);
    Task<ProfileResponse> UpdateAsync(int id, Model.Entities.Profile profile);
    Task<ProfileResponse> DeleteAsync(int id);
}