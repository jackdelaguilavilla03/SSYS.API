using AutoMapper;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ModelToResourceProduct: AutoMapper.Profile
{
    protected ModelToResourceProduct()
    {
        CreateMap<Product, ProductResource>();
        
    }
}