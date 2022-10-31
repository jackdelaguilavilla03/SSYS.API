using SSYS.API.SCM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services.Comunication;

public class ProductResponse: BaseResponse<Product>
{
    public ProductResponse(Product resource) : base(resource)
    {
    }

    public ProductResponse(string message) : base(message)
    {
    }
}