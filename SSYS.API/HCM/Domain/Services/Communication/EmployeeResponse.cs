using SSYS.API.HCM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.HCM.Domain.Services.Communication;

public class EmployeeResponse : BaseResponse<Employee>
{
    public EmployeeResponse(Employee resource) : base(resource)
    {
    }

    public EmployeeResponse(string message) : base(message)
    {
    }
}