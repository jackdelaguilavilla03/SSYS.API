using AutoMapper;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Resources;

namespace SSYS.API.CRM.Mapping;

public class ModelToResourceProfile : Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<Customer, CustomerResource>();
    }
}