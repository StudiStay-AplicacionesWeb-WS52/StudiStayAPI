using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;
using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Security.Domain.Services.Communication;

namespace StudiStayAPI.Security.Domain.Services;

/// <summary>
/// Define los servicios para User
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Obtiene todos los usuarios
    /// </summary>
    Task<IEnumerable<User>> ListAsync();
    
    /// <summary>
    /// Login de un usuario
    /// </summary>
    /// <param name="model">Datos del usuario a loguear</param>
    Task<LoginResponse> LoginAsync(LoginRequest model);

    /// <summary>
    /// Obtiene un usuario por su id
    /// </summary>
    /// <param name="id">Id del usuario a obtener</param>
    Task<User> GetByIdAsync(int id);
    
    /// <summary>
    /// Guarda un usuario
    /// </summary>
    /// <param name="model">Datos del usuario a registrar</param>
    Task<UserApiResponse> RegisterAsync(RegisterRequest model);
    
    /// <summary>
    /// Actualiza un usuario
    /// </summary>
    /// <param name="id">Id del usuario a actualizar</param>
    /// <param name="model">Datos del usuario a actualizar</param>
    Task<UserApiResponse> UpdateAsync(int id, UpdateUserRequest model);
    
    /// <summary>
    /// Elimina un usuario
    /// </summary>
    /// <param name="id">Id del usuario a eliminar</param>
    Task DeleteAsync(int id);
}