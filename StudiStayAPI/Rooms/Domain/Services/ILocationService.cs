using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

/// <summary>
/// Define los servicios para Post
/// </summary>
public interface ILocationService
{
    /// <summary>
    /// Obtiene todos los posts
    /// </summary>
    Task<IEnumerable<Location>> ListAsync();
    
    /// <summary>
    /// Obtiene un post por id
    /// </summary>
    /// <param name="locationId">Id del post</param>
    Task<LocationApiResponse> GetByIdAsync(int locationId);
    
    /// <summary>
    /// Obtiene todos los posts de un usuario
    /// </summary>
    /// <param name="locationId">Id del usuario</param>
    Task<IEnumerable<Location>> ListByLocationIdAsync(int userId);
    
    /// <summary>
    /// Guarda un post
    /// </summary>
    /// <param name="post">Datos del post a guardar</param>
    Task<LocationApiResponse> SaveAsync(Location location);
    
    /// <summary>
    /// Actualiza un post
    /// </summary>
    /// <param name="locationId">Id del post a actualizar</param>
    /// <param name="location">Datos del post a actualizar</param>
    Task<LocationApiResponse> UpdateAsync(int locationId, Location location);
    
    /// <summary>
    /// Elimina un post
    /// </summary>
    /// <param name="locationId">Id de la ubicación a eliminar</param>
    Task<LocationApiResponse> DeleteAsync(int locationId);
}