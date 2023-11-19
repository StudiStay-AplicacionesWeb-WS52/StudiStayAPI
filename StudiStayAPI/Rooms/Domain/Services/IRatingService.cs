using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

/// <summary>
/// Define los servicios para Rating
/// </summary>
public interface IRatingService
{
    /// <summary>
    /// Obtiene todos los Rating
    /// </summary>
    Task<IEnumerable<Rating>> ListAsync();
    
    /// <summary>
    /// Obtiene una reseña por id
    /// </summary>
    /// <param name="ratingId">Id del post</param>
    Task<RatingApiResponse> GetByIdAsync(int ratingId);
    
    /// <summary>
    /// Obtiene todas las reseñas de una lista
    /// </summary>
    /// <param name="ratingListId">Id del usuario</param>
    Task<IEnumerable<Rating>> ListByRatingListIdAsync(int ratingListId);
    
    /// <summary>
    /// Guarda una reseña
    /// </summary>
    /// <param name="rating">Datos del post a guardar</param>
    Task<RatingApiResponse> SaveAsync(Rating rating);
    
    /// <summary>
    /// Actualiza una reseña
    /// </summary>
    /// <param name="ratingId">Id de la reseña a actualizar</param>
    /// <param name="rating">Datos de la reseña a actualizar</param>
    Task<RatingApiResponse> UpdateAsync(int ratingId, Rating rating);
    
    /// <summary>
    /// Elimina un post
    /// </summary>
    /// <param name="ratingId">Id de la reseña a eliminar</param>
    Task<RatingApiResponse> DeleteAsync(int ratingId);
}