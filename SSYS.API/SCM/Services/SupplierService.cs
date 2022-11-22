using SSYS.API.SCM.Domain.Models;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Domain.Services.Comunication;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.SCM.Services;

public class SupplierService: ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _supplierRepository.ListAsync();
    }

    public async Task<IEnumerable<Supplier>> ListBySupplierIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<SupplierResponse> SaveAsync(Supplier supplier)
    {
        try
        {
            await _supplierRepository.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(supplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error ocurred while saving the supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> UpdateAsync(int supplierId, Supplier supplier)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(supplierId);

        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");
        
        //Validate Ruc
        var existingSupplierWithRuc = await _supplierRepository.FindBySupplierRuc(supplier.Ruc);

        if (existingSupplierWithRuc != null && existingSupplierWithRuc.Ruc == existingSupplier.Ruc)
            return new SupplierResponse("Supplier Ruc already exists");
        
        //Validate Name
        var existingSupplierWithName = await _supplierRepository.FindBySupplierName(supplier.Name);

        if (existingSupplierWithName != null && existingSupplierWithName.Name == existingSupplier.Name)
            return new SupplierResponse("Supplier Name already exists");

        existingSupplier.Name = supplier.Name;
        existingSupplier.Ruc = supplier.Ruc;
        existingSupplier.Address = supplier.Address;
        existingSupplier.Phone = supplier.Phone;
        existingSupplier.Email = supplier.Email;

        try
        {
            _supplierRepository.Update(existingSupplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error ocurres while updating the supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> DeleteAsync(int supplierId)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(supplierId);

        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");
        try
        {
            _supplierRepository.Remove(existingSupplier);
            await _unitOfWork.CompleteAsync();

            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occurred while trying to delete the supplier: {e.Message}");
        }
    }
}