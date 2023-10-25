using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories;

public interface IUniversityRepository
{
    /// <summary>
    /// Obtiene todas las universidades
    /// </summary>
    Task<IEnumerable<University>> ListAsync();
    
    /// <summary>
    /// Agrega una universidad
    /// </summary>
    /// <param name="university">Universidad a agregar</param>
    Task AddAsync(University university);
    
    /// <summary>
    /// Encuentra una universidad por su id
    /// </summary>
    /// <param name="universityId">Id de la universidad a buscar</param>
    Task<University> FindByIdAsync(int universityId);
    
    /// <summary>
    /// Encuentra una universidad por su nombre
    /// </summary>
    /// <param name="name">Nombre de la universidad a buscar</param>
    Task<University> FindByNameAsync(string name);
    
    /// <summary>
    /// Actualiza una universidad
    /// </summary>
    /// <param name="university">Universidad a actualizar</param>
    void Update(University university);
    
    /// <summary>
    /// Elimina una universidad por su id
    /// </summary>
    /// <param name="university">Universidad a eliminar</param>
    void Remove(University university);
}