using SSYS.API.SCM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services.Comunication;

public class PurchaseOrderResponse: BaseResponse<PurchaseOrder>
{
    public PurchaseOrderResponse(PurchaseOrder resource) : base(resource)
    {
    }

    public PurchaseOrderResponse(string message) : base(message)
    {
    }
}