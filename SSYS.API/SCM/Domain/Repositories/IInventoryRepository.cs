using SSYS.API.SCM.Domain.Models;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> ListAsync();
    Task AddAsync(Inventory inventory);
    Task<Inventory> FindByIdAsync(int id);
    Task<Inventory> FindByCategoryIdAsync(int id);
    Task<Inventory> FindByProductIdAsync(int id);
    Task<Inventory> FindByCategoryTitleAsync(string title);
    Task<Inventory> FindByProductTitleAsync(string title);
    void Update(Inventory inventory);
    void Remove(Inventory inventory);
}