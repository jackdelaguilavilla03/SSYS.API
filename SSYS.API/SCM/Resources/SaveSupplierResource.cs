using System.ComponentModel.DataAnnotations;

namespace SSYS.API.SCM.Resources;

public class SaveSupplierResource
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int Ruc { get; set; }
}