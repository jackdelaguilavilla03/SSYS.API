using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ResourceToModelSupplier: AutoMapper.Profile
{
    public ResourceToModelSupplier()
    {
        CreateMap<SaveSupplierResource, Supplier>();
    }
}