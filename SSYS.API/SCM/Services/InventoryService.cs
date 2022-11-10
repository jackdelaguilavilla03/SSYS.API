using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Domain.Services.Comunication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.SCM.Services;

public class InventoryService: IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InventoryService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
    {
        _inventoryRepository = inventoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Inventory>> ListAsync()
    {
        return await _inventoryRepository.ListAsync();
    }

    public async Task<IEnumerable<Inventory>> ListByIdAsync(int IdInventory)
    {
        return await _inventoryRepository.FindByIdAsync(IdInventory);
    }

    public Task<IEnumerable<Inventory>> ListByCategoryIdAsync(int IdCategory)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Inventory>> ListByProductIdAsync(int IdProduct)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Inventory>> ListByCategoryTitleAsync(string TitleCategory)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Inventory>> ListByProductTitleAsync(string TitleCategory)
    {
        throw new NotImplementedException();
    }

    public Task<InventoryResponse> SaveAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public Task<InventoryResponse> UpdateAsync(int inventoryId, Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public Task<InventoryResponse> DeleteAsync(int inventoryId)
    {
        throw new NotImplementedException();
    }
}