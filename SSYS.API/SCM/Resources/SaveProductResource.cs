using System.ComponentModel.DataAnnotations;

namespace SSYS.API.SCM.Resources;

public class SaveProductResource
{
   [Required]
   public string Title { get; set; }
   [Required]
   public int Amount { get; set; }
   [Required]
   public int Price { get; set; } 
}
