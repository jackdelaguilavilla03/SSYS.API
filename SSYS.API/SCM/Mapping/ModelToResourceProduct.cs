using AutoMapper;
using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ModelToResourceProduct: AutoMapper.Profile
{
    public ModelToResourceProduct()
    {
        //CreateMap<Product, ProductResource>();
        CreateMap<Product, ProductResource>();
    }
}