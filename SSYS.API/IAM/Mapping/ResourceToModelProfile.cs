using AutoMapper;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Services.Communication;
using SSYS.API.IAM.Resources;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.IAM.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>().ForAllMembers(
            options =>
                options.Condition((source, target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) &&
                            string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }
                )
        );
    }
}