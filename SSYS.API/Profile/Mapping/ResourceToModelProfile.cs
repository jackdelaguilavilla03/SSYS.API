using SSYS.API.Profile.Resources;

namespace SSYS.API.Profile.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveProfileResource, Domain.Model.Entities.Profile>();
    }
}