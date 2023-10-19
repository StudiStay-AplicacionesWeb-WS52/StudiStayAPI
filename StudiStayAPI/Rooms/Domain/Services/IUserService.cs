using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

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
    /// Guarda un usuario
    /// </summary>
    /// <param name="user">Datos del usuario a guardar</param>
    Task<UserApiResponse> SaveAsync(User user);
    
    /// <summary>
    /// Actualiza un usuario
    /// </summary>
    /// <param name="id">Id del usuario a actualizar</param>
    /// <param name="user">Datos del usuario a actualizar</param>
    Task<UserApiResponse> UpdateAsync(int id, User user);
    
    /// <summary>
    /// Elimina un usuario
    /// </summary>
    /// <param name="id">Id del usuario a eliminar</param>
    Task<UserApiResponse> DeleteAsync(int id);
}