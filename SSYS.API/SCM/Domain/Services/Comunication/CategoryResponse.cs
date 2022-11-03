using SSYS.API.SCM.Domain.Models;
using SSYS.API.Shared.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services.Comunication;

public class CategoryResponse: BaseResponse<Category>
{
    public CategoryResponse(Category resource) : base(resource)
    {
    }

    public CategoryResponse(string message) : base(message)
    {
    }
}