using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.Profile.Domain.Services.Communication;

public class ProfileResponse : BaseResponse<Model.Entities.Profile>
{
    public ProfileResponse(Model.Entities.Profile resource) : base(resource)
    {
    }

    public ProfileResponse(string message) : base(message)
    {
    }
}