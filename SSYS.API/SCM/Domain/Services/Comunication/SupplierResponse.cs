using SSYS.API.SCM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services.Comunication;

public class SupplierResponse: BaseResponse<Supplier>
{
    public SupplierResponse(Supplier resource) : base(resource)
    {
    }

    public SupplierResponse(string message) : base(message)
    {
    }
}