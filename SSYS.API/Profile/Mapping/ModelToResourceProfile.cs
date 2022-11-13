using SSYS.API.Profile.Resources;

namespace SSYS.API.Profile.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Model.Entities.Profile, ProfileResource>();
    }
}