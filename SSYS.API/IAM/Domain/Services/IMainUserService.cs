using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Services.Comunication;

namespace SSYS.API.IAM.Domain.Services;

public interface IMainUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<MainUser>> ListAsync();
    Task<MainUser> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(int id, UpdateRequest request);
    Task DeleteAsync(int id);
}