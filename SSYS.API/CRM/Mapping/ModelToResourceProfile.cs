using AutoMapper;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Resources;

namespace SSYS.API.CRM.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Customer, CustomerResource>();
    }
}