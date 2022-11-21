using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Services;
using SSYS.API.IAM.Interfaces.Internal;

namespace SSYS.API.IAM.Services;

public class UserContextFacade : IUserContextFacade
{
    private readonly IUserService _userService;

    public UserContextFacade(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<User> getUserById(int userId)
    {
        return await _userService.GetByIdAsync(userId);
    }
}