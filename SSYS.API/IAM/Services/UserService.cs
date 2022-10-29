using AutoMapper;
using SSYS.API.IAM.Authorization.Handlers.Interfaces;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Repositories;
using SSYS.API.IAM.Domain.Services;
using SSYS.API.IAM.Domain.Services.Comunication;
using SSYS.API.IAM.Exceptions;
using SSYS.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SSYS.API.IAM.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
    }
    
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByUserNameAsync(request.Username);
        Console.WriteLine($"Request: {request.Username}, {request.Password}");
        Console.WriteLine($"User: {user.Id},{user?.UserName}, {user?.Password}");

        if (user == null || !BCryptNet.Verify(request.Password,user.Password))
        {
            Console.WriteLine("Authentication failed");
            throw new AppException("Username or password is incorrect");
        }
        Console.WriteLine("Authentication success. About to generate token");
        // Authentication successful so generate jwt token
        var response = _mapper.Map<AuthenticateResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.Username}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Token: {response.Token}");
        return response;
    }

    public  async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        if (_userRepository.ExistsByUser(request.Username))
            throw new AppException($"Username {request.Username} is already taken");
        var user = _mapper.Map<User>(request);
        user.Password = BCryptNet.HashPassword(request.Password);

        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new AppException($"An error occurred when saving the user: {ex.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);
        var userWithUsername = await _userRepository.FindByUserNameAsync(request.Username);
        if (userWithUsername != null && userWithUsername.Id != id)
            throw new AppException($"Username {request.Username} is already taken");
        if (!string.IsNullOrEmpty(request.Password))
            user.Password = BCryptNet.HashPassword(request.Password);
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new AppException($"An error occurred when updating the user: {ex.Message}");
        }
    }

    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new AppException($"An error occurred when deleting the user: {ex.Message}");
        }
    }
}