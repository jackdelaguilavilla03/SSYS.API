using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Domain.Services.Comunication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.SCM.Services;

public class PurchaseOrderService: IPurchaseOrderService
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<PurchaseOrder>> ListAsync()
    {
        return await _purchaseOrderRepository.ListAsync();
    }

    public async Task<IEnumerable<PurchaseOrder>> ListBySupplierIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PurchaseOrderResponse> SaveAsync(PurchaseOrder purchaseOrder)
    {
        try
        {
            await _purchaseOrderRepository.AddAsync(purchaseOrder);
            await _unitOfWork.CompleteAsync();
            return new PurchaseOrderResponse(purchaseOrder);
        }
        catch (Exception e)
        {
            return new PurchaseOrderResponse($"An error occurred while saving the purchase order: {e.Message}");
        }
    }

    public async Task<PurchaseOrderResponse> UpdateAsync(int purchaseOrderId, PurchaseOrder purchaseOrder)
    {
        var existingPurchaseOrder = await _purchaseOrderRepository.FindByIdAsync(purchaseOrderId);

        if (existingPurchaseOrder == null)
            return new PurchaseOrderResponse("Purchase Order not found");

        existingPurchaseOrder.SupplierId = purchaseOrder.SupplierId;
        existingPurchaseOrder.DateTime = purchaseOrder.DateTime;

        try
        {
            _purchaseOrderRepository.Update(existingPurchaseOrder);
            await _unitOfWork.CompleteAsync();

            return new PurchaseOrderResponse(existingPurchaseOrder);
        }
        catch (Exception e)
        {
            return new PurchaseOrderResponse($"An error occurred while updating the purchase order: {e.Message}");
        }
    }

    public async Task<PurchaseOrderResponse> DeleteAsync(int purchaseOrderId)
    {
        var existingPurchaseOrder = await _purchaseOrderRepository.FindByIdAsync(purchaseOrderId);

        if (existingPurchaseOrder == null)
            return new PurchaseOrderResponse("Purchase Order not found");
        try
        {
            _purchaseOrderRepository.Remove(existingPurchaseOrder);
            await _unitOfWork.CompleteAsync();

            return new PurchaseOrderResponse(existingPurchaseOrder);
        }
        catch (Exception e)
        {
            return new PurchaseOrderResponse($"An error occurred while updating the purchase order: {e.Message}");
        }

    }
}