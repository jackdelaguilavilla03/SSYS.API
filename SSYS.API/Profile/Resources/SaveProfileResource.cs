using System.ComponentModel.DataAnnotations;

namespace SSYS.API.Profile.Resources;

public class SaveProfileResource
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Address { get; set; }
}