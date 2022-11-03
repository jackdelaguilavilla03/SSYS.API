using SSYS.API.Shared.Domain.Model;

namespace SSYS.API.SCM.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Amount { get; set; }
    public int Price { get; set; }
    public string Date { get; set; }
    public int IdCategory { get; set; }
}