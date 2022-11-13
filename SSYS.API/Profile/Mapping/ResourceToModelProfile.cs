using SSYS.API.Profile.Resources;

namespace SSYS.API.Profile.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProfileResource, Domain.Model.Entities.Profile>();
    }
}