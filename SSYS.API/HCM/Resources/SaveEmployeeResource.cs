using System.ComponentModel.DataAnnotations;

namespace SSYS.API.HCM.Resources;

public class SaveEmployeeResource
{
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(9)]
    [MinLength(9)]
    public int Phone { get; set; }
}