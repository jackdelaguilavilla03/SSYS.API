using System.ComponentModel.DataAnnotations;

namespace SSYS.API.SCM.Resources;

public class SaveProductResource
{
   public string Title { get; set; }
   public int Amount { get; set; }
   public int Price { get; set; } 
}
