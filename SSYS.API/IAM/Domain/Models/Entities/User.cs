using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.IAM.Domain.Models.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
}