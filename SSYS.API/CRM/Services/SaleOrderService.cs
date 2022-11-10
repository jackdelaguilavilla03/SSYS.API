using SSYS.API.CRM.Domain.Models;
using SSYS.API.CRM.Domain.Repositories;
using SSYS.API.CRM.Domain.Services;
using SSYS.API.CRM.Domain.Services.Communication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.CRM.Services;

public class SaleOrderService: ISaleOrderService
{

    private readonly ISaleOrderRepository _saleOrderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SaleOrderService(ISaleOrderRepository saleOrderRepository, IUnitOfWork unitOfWork)
    {
        _saleOrderRepository = saleOrderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SaleOrder>> ListAsync()
    {
        return await _saleOrderRepository.ListAsync();
    }

    public async Task<SaleOrderResponse> SaveAsync(SaleOrder saleOrder)
    {
        try
        {
            await _saleOrderRepository.AddAsync(saleOrder);

            await _unitOfWork.CompleteAsync();

            return new SaleOrderResponse(saleOrder);
        }
        catch (Exception e)
        {
            return new SaleOrderResponse($"An error ocurred while saving the sale order: {e.Message}");
        }
    }

    public async Task<SaleOrderResponse> UpdateAsync(int id, SaleOrder saleOrder)
    {
        var existingSaleOrder = await _saleOrderRepository.FindByIdAsync(id);

        if (existingSaleOrder == null)
            return new SaleOrderResponse("Sale Order not found.");

        existingSaleOrder.MethodOfPayment = saleOrder.MethodOfPayment;
        existingSaleOrder.Category = saleOrder.Category;
        existingSaleOrder.Product = saleOrder.Product;
        existingSaleOrder.Customer = saleOrder.Customer;
        existingSaleOrder.Amount = saleOrder.Amount;

        try
        {
            _saleOrderRepository.Update(existingSaleOrder);
            await _unitOfWork.CompleteAsync();

            return new SaleOrderResponse(existingSaleOrder);
        }
        catch (Exception e)
        {
            return new SaleOrderResponse($"An error occurred while updating the sale order: {e.Message}");
        }
    }

    public async Task<SaleOrderResponse> DeleteAsync(int id)
    {
        var existingSaleOrder = await _saleOrderRepository.FindByIdAsync(id);

        if (existingSaleOrder == null)
            return new SaleOrderResponse("Sale order not found");

        try
        {
            _saleOrderRepository.Remove(existingSaleOrder);
            await _unitOfWork.CompleteAsync();

            return new SaleOrderResponse(existingSaleOrder);
        }
        catch (Exception e)
        {
            return new SaleOrderResponse($"An error ocurred while deleting the sale order: {e.Message}");
        }
    }
}