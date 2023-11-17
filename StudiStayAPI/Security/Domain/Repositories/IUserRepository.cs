using StudiStayAPI.Security.Domain.Models;

namespace StudiStayAPI.Security.Domain.Repositories;

/// <summary>
/// Define las operaciones CRUD para User
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Obtiene todos los usuarios
    /// </summary>
    Task<IEnumerable<User>> ListAsync();
    
    /// <summary>
    /// Agrega un usuario
    /// </summary>
    /// <param name="user">Usuario a agregar</param>
    Task AddAsync(User user);
    
    /// <summary>
    /// Encuentra un usuario por su id
    /// </summary>
    /// <param name="id">Id del usuario a buscar</param>
    Task<User> FindByIdAsync(int id);
    
    /// <summary>
    /// Encuentra un usuario por su email
    /// </summary>
    /// <param name="email">Email del usuario a buscar</param>
    Task<User> FindByEmailAsync(string email);

    /// <summary>
    /// Verifica si existe un usuario con el email dado
    /// </summary>
    /// <param name="email">Email del usuario a buscar</param>
    public bool ExistsByEmail(string email);
    
    /// <summary>
    /// Encuentra un usuario por su id
    /// </summary>
    /// <param name="id">Id del usuario a buscar</param>
    User FindById(int id);
    
    /// <summary>
    /// Actualiza un usuario
    /// </summary>
    /// <param name="user">Usuario a actualizar</param>
    void Update(User user);
    
    /// <summary>
    /// Elimina un usuario
    /// </summary>
    /// <param name="user">Usuario a eliminar</param>
    void Remove(User user);
}