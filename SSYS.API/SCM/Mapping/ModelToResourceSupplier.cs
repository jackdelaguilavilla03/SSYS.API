using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ModelToResourceSupplier: AutoMapper.Profile
{
    public ModelToResourceSupplier()
    {
        CreateMap<Supplier, SupplierResource>();
    }
}