using SSYS.API.SCM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services.Comunication;

public class InventoryResponse: BaseResponse<Inventory>
{
    public InventoryResponse(Inventory resource) : base(resource)
    {
    }

    public InventoryResponse(string message) : base(message)
    {
    }
}