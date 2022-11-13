using System.ComponentModel.DataAnnotations;

namespace SSYS.API.Profile.Resources;

public class SaveProfileResource
{
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(9)]
    [MinLength(9)]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(120)]
    public string Address { get; set; }
}