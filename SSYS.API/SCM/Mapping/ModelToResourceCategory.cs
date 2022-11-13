using AutoMapper;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ModelToResourceCategory: AutoMapper.Profile
{
    public ModelToResourceCategory()
    {
        CreateMap<Category, CategoryResource>();
    }
}