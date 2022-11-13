using AutoMapper;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ResourceToModelCategory: AutoMapper.Profile
{
    public ResourceToModelCategory()
    {
        CreateMap<SaveCategoryResource, Category>();
    }
}