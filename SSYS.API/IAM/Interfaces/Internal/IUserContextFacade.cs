using SSYS.API.IAM.Domain.Models.Entities;

namespace SSYS.API.IAM.Interfaces.Internal;

public interface IUserContextFacade
{
    Task<User> getUserById(int userId);
}