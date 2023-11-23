using System.Net;
using AutoMapper;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Security.Domain.Repositories;
using StudiStayAPI.Security.Domain.Services;
using StudiStayAPI.Security.Domain.Services.Communication;
using StudiStayAPI.Security.Jwt;
using StudiStayAPI.Shared.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace StudiStayAPI.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly JwtHandler jwtHandler;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, JwtHandler jwtHandler)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.jwtHandler = jwtHandler;
    }
    
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await userRepository.ListAsync();
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest model)
    {
        // obtiene el usuario por su email
        var user = await userRepository.FindByEmailAsync(model.Email);
        
        // valida que el usuario exista y que la contraseña sea correcta
        if (user == null || !BCryptNet.Verify(model.Password, user.Password))
        {
            throw new AppException(HttpStatusCode.BadRequest, "Email or password is incorrect");
        }
 
        // si el usuario existe y la contraseña es correcta, genera el token
        var response = mapper.Map<LoginResponse>(user);
        response.Token = jwtHandler.GenerateToken(user);
        
        return response;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task<UserApiResponse> RegisterAsync(RegisterRequest model)
    {
        // valida que el email no esté registrado
        if (userRepository.ExistsByEmail(model.Email))
        {
            throw new AppException(HttpStatusCode.Conflict, $"Email '{model.Email}' is already taken");
        } 
        
        // mapea el modelo a un objeto User
        var user = mapper.Map<User>(model);
        
        // hashear la contraseña
        user.Password = BCryptNet.HashPassword(model.Password);
        user.ImageUrl = "https://source.unsplash.com/random/500X500?person";
        user.Role = "USER";
        
        // registra el usuario
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return new UserApiResponse(user);
        }
        catch (Exception e)
        {
            throw new AppException(HttpStatusCode.InternalServerError, $"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task<UserApiResponse> UpdateAsync(int id, UpdateUserRequest model)
    {
        // obtiene el usuario por su id
        var existingUser = GetById(id);
        if (existingUser == null) return new UserApiResponse("User not found.");
        
        //valida si el email ya existe y no es el mismo user
        var existingUserWithEmail = userRepository.FindByEmailAsync(model.Email);
        if (existingUserWithEmail != null && existingUserWithEmail.Id != existingUser.Id) 
            throw new AppException(HttpStatusCode.Conflict, $"Email '{model.Email}' is already taken");
        
        // mapea el modelo a un objeto User
        mapper.Map(model, existingUser);
        
        //modifica el post
        existingUser.FullName = model.FullName ?? existingUser.FullName;
        existingUser.Email = model.Email ?? existingUser.Email;
        existingUser.Phone = model.Phone ?? existingUser.Phone;
        
        // actualiza el usuario
        try
        {
            userRepository.Update(existingUser);
            await unitOfWork.CompleteAsync();
            return new UserApiResponse(existingUser);
        }
        catch (Exception e)
        {
            throw new AppException(HttpStatusCode.InternalServerError, $"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        // obtiene el usuario por su id
        var user = GetById(id);
 
        // elimina el usuario
        try
        {
            userRepository.Remove(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException(HttpStatusCode.InternalServerError, $"An error occurred while deleting the user: {e.Message}");
        }
    }
    
    // helper methods
    private User GetById(int id)
    {
        var user = userRepository.FindById(id);
        if (user == null) throw new AppException(HttpStatusCode.NotFound, "User not found");
        return user;
    }
}