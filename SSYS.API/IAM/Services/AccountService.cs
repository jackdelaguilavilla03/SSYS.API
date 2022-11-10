using SSYS.API.IAM.Domain.Models.Entities;
using SSYS.API.IAM.Domain.Services;
using AutoMapper;
using SSYS.API.IAM.Domain.Repositories;
using SSYS.API.Shared.Domain.Repositories;

namespace SSYS.API.IAM.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRespository _accountRespository;
    private readonly  IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public AccountService(IAccountRespository accountRespository,IMapper mapper, IUnitOfWork unitOfWork)
    {
        _accountRespository = accountRespository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Account?>> ListAsync()
    {
        return await _accountRespository.ListAsync();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await _accountRespository.FindByIdAsync(id);
    }

    public async Task RegisterAsync()
    {
        
    }

    public async Task UpdateAsync(int id)
    {
        var existingAccount = await _accountRespository.FindByIdAsync(id);
        if (existingAccount == null)
            return;

        _accountRespository.Update(existingAccount);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existingAccount = await _accountRespository.FindByIdAsync(id);
        if (existingAccount == null)
            return;
        _accountRespository.Remove(existingAccount);
        await _unitOfWork.CompleteAsync();
    }
}