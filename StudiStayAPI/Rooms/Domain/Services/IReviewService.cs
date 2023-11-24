using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public interface IReviewService
{
    /// <summary>
    /// Obtiene una lista de reviews.
    /// </summary>
    Task<IEnumerable<Review>> ListAsync();
    
    /// <summary>
    /// Guarda un review.
    /// </summary>
    /// <param name="review">Review a guardar.</param>
    /// <returns>Response del review guardado.</returns>
    Task<ReviewApiResponse> SaveAsync(Review review);
    
    /// <summary>
    /// Elimina un review por id.
    /// </summary>
    /// <param name="id">Id del review a eliminar.</param>
    Task<ReviewApiResponse> DeleteAsync(int id);
    
    /// <summary>
    /// Obtiene una lista de reviews por post.
    /// </summary>
    /// <param name="postId">Id del post.</param>
    Task<IEnumerable<Review>> ListByPostIdAsync(int postId);
    
}