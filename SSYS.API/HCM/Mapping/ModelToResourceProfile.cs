using AutoMapper;
using SSYS.API.HCM.Domain.Models;
using SSYS.API.HCM.Resources;

namespace SSYS.API.HCM.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Employee, EmployeeResource>();
    }
}