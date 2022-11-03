using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Domain.Services.Comunication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.SCM.Services;

public class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }

    public async Task<IEnumerable<Category>> ListByCategoryIdAsync(int id)
    {
        return await _categoryRepository.ListByCategoryIdAsync(id);
    }

    public async Task<CategoryResponse> SaveAsync(Category category)
    {
        

        // Validate Title

        var existingTutorialWithTitle = await _categoryRepository.FindByCategoryTitleAsync(category.Title);

        if (existingTutorialWithTitle != null)
            return new CategoryResponse("El nombre de la categoria ya existe");
        
        // Perform Adding

        try
        {
            // Add Tutorial
            await _categoryRepository.AddAsync(category);

            // Complete Transaction
            await _unitOfWork.CompleteAsync();

            // Return response
            return new CategoryResponse(category);
        }
        catch(Exception e)
        {
            // Error Handling
            return new CategoryResponse($"Ocurrio un error mmientras se agregaba la categoria:{e.Message}");
        }
    }

    public async Task<CategoryResponse> UpdateAsync(int categoryId, Category category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(categoryId);

        if (existingCategory == null)
            return new CategoryResponse("El ID de la categoría no existe");

        // Modify Fields

        existingCategory.Title = category.Title;
        existingCategory.Description = category.Description;

        // Perform Update

        try
        {
            _categoryRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            // Error Handling
            return new CategoryResponse($"Ocurrio un error mientras se actualizaba la categoría:  {e.Message}");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(int categoryId)
    {
        var exitingCategory = await _categoryRepository.FindByIdAsync(categoryId);
        if (exitingCategory == null)
            return new CategoryResponse("La categoría no existe");
        try
        {
            _categoryRepository.Remove((exitingCategory));
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(exitingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"Ocurrio un error mientras se elimanaba la categoria: {e.Message}");
        }
    }

    public async Task<IEnumerable<Category>> FindByCategoryTitleAsync(string title)
    {
        return await _categoryRepository.FindByCategoryTitleAsync(title);
    }
}