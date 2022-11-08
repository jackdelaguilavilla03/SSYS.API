using SSYS.API.Profiles.Domain.Models;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models.Entities;

public class Account : BaseModel
{
    // Relationship
    public UserInformation UserInformation { get; set; }
    public BussinessInformation BussinessInformation { get; set; }
    public IList<User>? Users { get; set; }
}