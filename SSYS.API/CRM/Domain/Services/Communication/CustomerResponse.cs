using SSYS.API.CRM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.CRM.Domain.Services.Communication;

public class CustomerResponse : BaseResponse<Customer>
{
    public CustomerResponse(Customer resource) : base(resource)
    {
    }

    public CustomerResponse(string message) : base(message)
    {
    }
}