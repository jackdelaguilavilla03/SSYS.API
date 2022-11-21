using System.ComponentModel.DataAnnotations.Schema;
using SSYS.API.IAM.Domain.Models.Entities;

namespace SSYS.API.Profile.Domain.Model.Entities;

public class Profile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}