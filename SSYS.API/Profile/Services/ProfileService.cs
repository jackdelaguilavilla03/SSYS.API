using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Interfaces.Internal;
using SSYS.API.Profile.Domain.Repositories;
using SSYS.API.Profile.Domain.Services;
using SSYS.API.Profile.Domain.Services.Communication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.Profile.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContextFacade _userContextFacade;

    public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork, IUserContextFacade userContextFacade)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
        _userContextFacade = userContextFacade;
    }

    public async Task<IEnumerable<Domain.Model.Entities.Profile>> ListAsync()
    {
        return await _profileRepository.ListAsync();
    }

    public async Task<ProfileResponse> SaveAsync(Domain.Model.Entities.Profile profile, int userId)
    {

        var existingUser = _userContextFacade.getUserById(userId).Result;

        if (existingUser == null)
        {
            return new ProfileResponse("Error 404, user not found.");
            
        }

        profile.UserId = existingUser.Id;
        profile.User = existingUser;
        
        try
        {
            await _profileRepository.AddAsync(profile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(profile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"A error went while adding profile: {e.Message}");
        }
    }

    public async Task<ProfileResponse> UpdateAsync(int id, Domain.Model.Entities.Profile profile)
    {
        var existingProfile = await _profileRepository.FindByIdAsync(id);

        if (existingProfile == null)
            return new ProfileResponse("Profile not found.");

        existingProfile.FirstName = profile.FirstName;
        existingProfile.LastName = profile.LastName;
        existingProfile.PhoneNumber = profile.PhoneNumber;
        existingProfile.Address = profile.Address;

        try
        {
            _profileRepository.Update(existingProfile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(existingProfile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"An error occurred while updating profile: {e.Message}");
        }
    }

    public async Task<ProfileResponse> DeleteAsync(int id)
    {
        var existingProfile = await _profileRepository.FindByIdAsync(id);

        if (existingProfile == null)
            return new ProfileResponse("Profile not found.");

        try
        {
            _profileRepository.Remove(existingProfile);
            await _unitOfWork.CompleteAsync();

            return new ProfileResponse(existingProfile);
        }
        catch (Exception e)
        {
            return new ProfileResponse($"An error occurred while deleting the employee: {e.Message}");
        }
    }
}