using System.ComponentModel.DataAnnotations;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.CRM.Resources;

public class SaveSaveOrderResource
{
    [Required]
    public MethodOfPayment MethodOfPayment { get; set; }
    public Customer Customer { get; set; }
    [Required]
    public Category Category { get; set; }
    [Required]
    public Product Product { get; set; }
    [Required]
    public int Amount { get; set; }
}