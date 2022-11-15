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

    public async Task<IEnumerable<Inventory>> ListByCategoryIdAsync(int IdCategory)
    {
        return await _inventoryRepository.FindByCategoryIdAsync(IdCategory);
    }

    public async Task<IEnumerable<Inventory>> ListByProductIdAsync(int IdProduct)
    {
        return await _inventoryRepository.FindByProductIdAsync(IdProduct);
    }

    public async Task<IEnumerable<Inventory>> ListByCategoryTitleAsync(string TitleCategory)
    {
        return await _inventoryRepository.FindByCategoryTitleAsync(TitleCategory);
    }

    public async Task<IEnumerable<Inventory>> ListByProductTitleAsync(string TitleProduct)
    {
        return await _inventoryRepository.FindByProductTitleAsync(TitleProduct);
    }

    public async Task<InventoryResponse> SaveAsync(Inventory inventory)
    {
        try
        {
            await _inventoryRepository.AddAsync(inventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(inventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error ocurred while saving the inventory: {e.Message}");
        }
    }

    public async Task<InventoryResponse> UpdateAsync(int inventoryId, Inventory inventory)
    {
        var existingInventory = await _inventoryRepository.FindByInventoryIdAsync(inventoryId);
        if (existingInventory == null)
            return new InventoryResponse("inventory no found");
        try
        {
            _inventoryRepository.Update(inventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(inventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error ocurred while updating the inventory: {e.Message}");
        }
    }

    public async Task<InventoryResponse> DeleteAsync(int inventoryId)
    {
        var existingInventory = await _inventoryRepository.FindByInventoryIdAsync(inventoryId);
        if (existingInventory == null)
            return new InventoryResponse("inventory no found");
        try
        {
            _inventoryRepository.Remove(existingInventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(existingInventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error ocurred while updating the inventory: {e.Message}");
        }
    }
}