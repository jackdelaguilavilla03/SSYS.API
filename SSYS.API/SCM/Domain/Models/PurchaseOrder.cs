namespace SSYS.API.SCM.Domain.Models;

public class PurchaseOrder
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public DateTime DateTime { get; set; }
    
}