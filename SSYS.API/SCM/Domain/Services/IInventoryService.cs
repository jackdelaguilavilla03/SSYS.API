using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

namespace SSYS.API.SCM.Domain.Services;

public interface IInventoryService
{
   Task<IEnumerable<Inventory>> ListAsync();
   Task<IEnumerable<Inventory>> ListByIdAsync(int IdInventory);
   Task<IEnumerable<Inventory>> ListByCategoryIdAsync(int IdCategory);
   Task<IEnumerable<Inventory>> ListByProductIdAsync(int IdProduct);
   Task<IEnumerable<Inventory>> ListByCategoryTitleAsync(string TitleCategory);
   Task<IEnumerable<Inventory>> ListByProductTitleAsync(string TitleCategory);
   Task<InventoryResponse> SaveAsync(Inventory inventory);
   Task<InventoryResponse> UpdateAsync(int inventoryId, Inventory inventory);
   Task<InventoryResponse> DeleteAsync(int inventoryId);
}