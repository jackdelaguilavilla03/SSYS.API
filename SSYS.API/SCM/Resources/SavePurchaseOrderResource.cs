using System.ComponentModel.DataAnnotations;

namespace SSYS.API.SCM.Resources;

public class SavePurchaseOrderResource
{
    [Required]
    public int SupplierId { get; set; }
}