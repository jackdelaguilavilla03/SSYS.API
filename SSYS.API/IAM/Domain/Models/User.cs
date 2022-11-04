using System.Text.Json.Serialization;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models;

public class User : BaseModel
{
    public enum Status
    {
        Active,
        Inactive,
        Locked,
        Deleted
    }

    public enum Role
    {
        Admin,
        Employee,
        Manager,
        Supervisor,
        Owner
    }

    public string Username { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public Status UserStatus { get; set; }

    // Relationship
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public Role UserRoles { get; set; }
}