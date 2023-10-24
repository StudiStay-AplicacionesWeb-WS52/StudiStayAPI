using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

/// <summary>
/// Define los servicios para Post
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Obtiene todos los posts
    /// </summary>
    Task<IEnumerable<Post>> ListAsync();
    
    /// <summary>
    /// Obtiene un post por id
    /// </summary>
    /// <param name="postId">Id del post</param>
    Task<PostApiResponse> GetByIdAsync(int postId);
    
    /// <summary>
    /// Obtiene todos los posts de un usuario
    /// </summary>
    /// <param name="userId">Id del usuario</param>
    Task<IEnumerable<Post>> ListByUserIdAsync(int userId);
    
    /// <summary>
    /// Guarda un post
    /// </summary>
    /// <param name="post">Datos del post a guardar</param>
    Task<PostApiResponse> SaveAsync(Post post);
    
    /// <summary>
    /// Actualiza un post
    /// </summary>
    /// <param name="postId">Id del post a actualizar</param>
    /// <param name="post">Datos del post a actualizar</param>
    Task<PostApiResponse> UpdateAsync(int postId, Post post);
    
    /// <summary>
    /// Elimina un post
    /// </summary>
    /// <param name="postId">Id del post a eliminar</param>
    Task<PostApiResponse> DeleteAsync(int postId);
}