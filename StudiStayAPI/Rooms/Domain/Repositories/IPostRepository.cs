using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories;

/// <summary>
/// Define las operaciones CRUD para Post
/// </summary>
public interface IPostRepository
{
    /// <summary>
    /// Obtiene todos los posts
    /// </summary>
    Task<IEnumerable<Post>> ListAsync();
    
    /// <summary>
    /// Agrega un post
    /// </summary>
    /// <param name="post">Post a agregar</param>
    Task AddAsync(Post post);
    
    /// <summary>
    /// Encuentra un post por su id
    /// </summary>
    /// <param name="postId">Id del post a buscar</param>
    Task<Post> FindByIdAsync(int postId);
    
    /// <summary>
    /// Encuentra un post por su titulo
    /// </summary>
    /// <param name="title">Titulo del post a buscar</param>
    Task<Post> FindByTitleAsync(string title);
    
    /// <summary>
    /// Encuentra un post por el id del usuario
    /// </summary>
    /// <param name="userId">Id del usuario del post a buscar</param>
    Task<IEnumerable<Post>> FindByUserIdAsync(int userId);
    
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