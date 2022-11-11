using SSYS.API.IAM.Domain.Models;

namespace SSYS.API.IAM.Domain.Services.Communication;

public abstract class UpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}