using System.Text.Json.Serialization;
using SSYS.API.IAM.Domain.Models.Enumeration;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models.Entities;

public class User : BaseModel
{
    public string Username { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public Status UserStatus { get; set; }

    // Relationship
    public int AccountId { get; set; }
    public Role UserRoles { get; set; }
}