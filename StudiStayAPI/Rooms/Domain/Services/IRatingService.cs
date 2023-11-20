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
    /// Obtiene las reseñas de 
    /// </summary>
    /// <param name="ratingListId">Id del usuario</param>
    Task<RatingList> ListByRatingListIdAsync(int ratingListId);
    
    /// <summary>
    /// Guarda una reseña
    /// </summary>
    /// <param name="ratingList">Datos del post a guardar</param>
    Task<RatingApiResponse> SaveAsync(Rating ratingList);
    
    /// <summary>
    /// Actualiza una reseña
    /// </summary>
    /// <param name="ratingListId">Id de la reseña a actualizar</param>
    /// <param name="ratingList">Datos de la reseña a actualizar</param>
    Task<RatingApiResponse> UpdateAsync(int ratingListId, RatingList ratingList);
    
    /// <summary>
    /// Elimina un post
    /// </summary>
    /// <param name="ratingListId">Id de la reseña a eliminar</param>
    Task<RatingApiResponse> DeleteAsync(int ratingListId);
}