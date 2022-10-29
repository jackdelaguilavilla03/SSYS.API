using System.Text.Json.Serialization;
using SSYS.API.Profiles.Domain.Models;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models;

public class MainUser : BaseModel
{
    public string Username { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    
    // Relationship
    public UserInformation UserInformation { get; set; }
    public BussinessInformation BussinessInformation { get; set; }
    public IList<User>? Users { get; set; }
}