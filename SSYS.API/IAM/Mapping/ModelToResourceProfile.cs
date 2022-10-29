using AutoMapper;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Services.Comunication;
using SSYS.API.IAM.Resources;

namespace SSYS.API.IAM.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>(0);
        CreateMap<User, UserResource>();
        CreateMap<MainUser, AuthenticateResponse>();
        CreateMap<MainUser, MainUserResource>();
    }
}