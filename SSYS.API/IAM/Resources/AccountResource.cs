using SSYS.API.IAM.Domain.Models.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace SSYS.API.IAM.Resources;
public class AccountResource
{
    public int Id { get; set; }
    public ICollection<User> Users { get; set; }
}