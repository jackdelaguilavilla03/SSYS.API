using AutoMapper;
using SSYS.API.HCM.Domain.Models;
using SSYS.API.HCM.Resources;

namespace SSYS.API.HCM.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveEmployeeResource, Employee>();
    }
}