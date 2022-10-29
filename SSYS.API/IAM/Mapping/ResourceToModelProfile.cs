using AutoMapper;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Services.Comunication;
using SSYS.API.IAM.Resources;

namespace SSYS.API.IAM.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>().ForAllMembers(options =>
            options.Condition((source, target, property) =>
                {
                    if (property == null) return false;

                    return property is not string || !string.IsNullOrEmpty((string)property);
                }
            )
        );
    }
}