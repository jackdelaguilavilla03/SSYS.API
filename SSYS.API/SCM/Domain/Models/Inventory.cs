namespace SSYS.API.SCM.Domain.Models;

public class Inventory
{
   public int Id { get; set; } 
   public string ProductTitle { get; set; }
   public string ProductCategory { get; set; }
   public int IdProduct { get; set; }
   public int IdCategory { get; set; }
}