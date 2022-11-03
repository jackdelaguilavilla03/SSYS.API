using AutoMapper;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ResourceToModelCategory: Profile
{
    protected ResourceToModelCategory()
    {
        CreateMap<SaveCategoryResource, Category>();
    }
}