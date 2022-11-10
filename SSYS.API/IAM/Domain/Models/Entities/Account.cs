using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models.Entities;

public class Account : BaseModel
{
    // Relationship
    public ICollection<User>? Users { get; set; }
}