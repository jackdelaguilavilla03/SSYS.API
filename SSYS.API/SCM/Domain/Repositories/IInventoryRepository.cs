using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services.Comunication;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> ListAsync();
    Task AddAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> FindByIdAsync(int id);
    Task<IEnumerable<Inventory>> FindByCategoryIdAsync(int id);
    Task<IEnumerable<Inventory>> FindByProductIdAsync(int id);
    Task<IEnumerable<Inventory>> FindByCategoryTitleAsync(string title);
    Task<IEnumerable<Inventory>> FindByProductTitleAsync(string title);
    void Update(Inventory inventory);
    void Remove(Inventory inventory);
    Task<Inventory> FindByInventoryIdAsync(int idInventory);
}