using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models.Entities;

public class User : BaseModel
{
    public string Username { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}