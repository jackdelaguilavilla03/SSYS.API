using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Resources;

namespace SSYS.API.SCM.Mapping;

public class ModelToResourcePurchaseOrder: AutoMapper.Profile
{
    public ModelToResourcePurchaseOrder()
    {
        CreateMap<PurchaseOrder, PurchaseOrderResource>();
    }
}