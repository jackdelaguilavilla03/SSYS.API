using AutoMapper;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Resources;

namespace SSYS.API.CRM.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCustomerResource, Customer>();
    }
}