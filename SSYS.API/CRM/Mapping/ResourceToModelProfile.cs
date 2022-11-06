using AutoMapper;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Resources;

namespace SSYS.API.CRM.Mapping;

public class ResourceToModelProfile : Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveCustomerResource, Customer>();
    }
}