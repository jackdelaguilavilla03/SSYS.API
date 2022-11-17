using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.CRM.Domain.Models;

public enum MethodOfPayment
{
    Debt,
    Paid
}

public class SaleOrder
{
    public int Id { get; set; }
    public MethodOfPayment MethodOfPayment { get; set; }
    public Customer Customer { get; set; }
    public Category Category { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
}