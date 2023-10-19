using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

/// <summary>
/// Clase que implementa la interfaz IUserService
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    
    //inyecccion de dependencias
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await userRepository.ListAsync();
    }

    public async Task<UserApiResponse> SaveAsync(User user)
    {
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return new UserApiResponse(user);
        }
        catch (Exception e)
        {
            return new UserApiResponse($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task<UserApiResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await userRepository.FindByIdAsync(id);
        if (existingUser == null)
            return new UserApiResponse("User not found.");
        
        //modifica los campos del usuario (solo los que no son nulos)
        existingUser.FullName = user.FullName ?? existingUser.FullName;
        existingUser.Email = user.Email ?? existingUser.Email;
        existingUser.Password = user.Password ?? existingUser.Password;
        existingUser.Phone = user.Phone ?? existingUser.Phone;
        existingUser.Role = user.Role ?? existingUser.Role;
        existingUser.ImageUrl = user.ImageUrl ?? existingUser.ImageUrl;
        
        try
        {
            userRepository.Update(existingUser);
            await unitOfWork.CompleteAsync();
            return new UserApiResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserApiResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<UserApiResponse> DeleteAsync(int id)
    {
        var existingUser = await userRepository.FindByIdAsync(id);
        if (existingUser == null)
            return new UserApiResponse("User not found.");
        
        try
        {
            userRepository.Remove(existingUser);
            await unitOfWork.CompleteAsync();
            return new UserApiResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserApiResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }
}