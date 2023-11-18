using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories;

/// <summary>
/// Define las operaciones CRUD para Post
/// </summary>
public interface IRatingListRepository
{
    /// <summary>
    /// Obtiene todas las reseñas
    /// </summary>
    Task<IEnumerable<Rating>> ListAsync();
    
    /// <summary>
    /// Agrega una reseña
    /// </summary>
    /// <param name="rating">Reseña a agregar</param>
    Task AddAsync(Rating rating);
    
    /// <summary>
    /// Encuentra un post por su id
    /// </summary>
    /// <param name="ratingId">Id de la reseña a buscar</param>
    Task<Post> FindByIdAsync(int ratingId);
    
    /// <summary>
    /// Encuentra un post por el id del usuario
    /// </summary>
    /// <param name="ratingListId">Id de la lista de  del post a buscar</param>
    Task<IEnumerable<Post>> FindByRatingListIdAsync(int ratingListId);

   
    
    /// <summary>
    /// Actualiza un post
    /// </summary>
    /// <param name="post">Post a actualizar</param>
    void Update(Post post);
    
    /// <summary>
    /// Elimina un post
    /// </summary>
    /// <param name="post">Post a eliminar</param>
    void Remove(Post post);
}