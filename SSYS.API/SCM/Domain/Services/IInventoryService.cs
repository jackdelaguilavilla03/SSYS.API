using SSYS.API.SCM.Domain.Models;

namespace SSYS.API.SCM.Domain.Services;

public class IInventoryService
{
   Task<IEnumerable<Inventory>> ListAsync();
   Task<IEnumerable<Inventory>> ListByCategoryIdAsync(int IdCategory);
   Task<IEnumerable<Inventory>> ListByProductIdAsync(int IdProduct);
   Task<IEnumerable<Inventory>> ListByCategoryTitleAsync(string TitleCategory);
   Task<IEnumerable<Inventory>> ListByProductTitleAsync(string TitleCategory);
}