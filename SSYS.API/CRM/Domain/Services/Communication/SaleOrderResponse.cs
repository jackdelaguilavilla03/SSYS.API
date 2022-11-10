using SSYS.API.CRM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.CRM.Domain.Services.Communication;

public class SaleOrderResponse: BaseResponse<SaleOrder>
{
    public SaleOrderResponse(SaleOrder resource) : base(resource)
    {
    }

    public SaleOrderResponse(string message) : base(message)
    {
    }
}