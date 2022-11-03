using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Domain.Services.Comunication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.SCM.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public Task<IEnumerable<Product>> ListByCategoryIdAsync(int product)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while saving the category: {e.Message}");

        }
    }

    public async Task<ProductResponse> UpdateAsync(int id, Product product)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Category not found.");

        existingProduct.Title = product.Title;
        existingProduct.Amount = product.Amount;
        existingProduct.Price = product.Price;
        existingProduct.IdCategory = product.IdCategory;
        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while updating the category: {e.Message}");
        }  
    }

    public async Task<ProductResponse> DeleteAsync(int id)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Category not found.");

        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }

    public Task<IEnumerable<Product>> FindByProductPriceAsync(int price)
    {
        throw new NotImplementedException();
    }
}