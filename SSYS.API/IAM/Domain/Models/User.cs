using System.Text.Json.Serialization;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models;

public class User : BaseModel
{
    public enum Status { Active, Inactive, Locked, Deleted }
    public string Username { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public Status UserStatus { get; set; }
    
    // Relationship
    public int MainUserId { get; set; }
    public MainUser MainUser { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public string UserName { get; set; }
}