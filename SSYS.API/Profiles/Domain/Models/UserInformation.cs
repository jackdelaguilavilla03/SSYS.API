using Microsoft.VisualBasic;

namespace SSYS.API.Profiles.Domain.Models;

public class UserInformation
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public long UserPhone { get; set; }
    //public string UserAddress { get; set; } = string.Empty;
    
}