using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

/// <summary>
/// Define los servicios para Rating
/// </summary>
public interface IRatingListService
{
    /// <summary>
    /// Obtiene todos los Rating
    /// </summary>
    Task<IEnumerable<RatingList>> ListAsync();
    
    /// <summary>
    /// Obtiene una reseña por id
    /// </summary>
    /// <param name="ratingListId">Id del post</param>
    Task<RatingListApiResponse> GetByIdAsync(int ratingId);
    
    /// <summary>
    /// Guarda una reseña
    /// </summary>
    /// <param name="ratingList">Datos del post a guardar</param>
    Task<RatingApiResponse> SaveAsync(RatingList ratingList);
    
}