using System.ComponentModel.DataAnnotations;

namespace SSYS.API.CRM.Resources;

public class SaveCustomerResource
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int Phone { get; set; }
}