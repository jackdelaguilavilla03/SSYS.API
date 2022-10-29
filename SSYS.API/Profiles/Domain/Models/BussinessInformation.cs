using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.Profiles.Domain.Models;

public class BussinessInformation : BaseModel
{
    public string BussinessName { get; set; } = string.Empty;
    public string BussinessDescription { get; set; } = string.Empty;
}