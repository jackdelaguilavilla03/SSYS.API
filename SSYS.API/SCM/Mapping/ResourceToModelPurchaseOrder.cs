using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ResourceToModelPurchaseOrder: AutoMapper.Profile
{
    public ResourceToModelPurchaseOrder()
    {
        CreateMap<SavePurchaseOrderResource, PurchaseOrder>();
    }
}