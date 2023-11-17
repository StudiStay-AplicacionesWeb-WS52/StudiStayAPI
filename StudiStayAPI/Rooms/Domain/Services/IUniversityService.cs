using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

public interface IUniversityService
{
    /// <summary>
    /// Obtiene todas las universidades
    /// </summary>
    Task<IEnumerable<University>> ListAsync();
    
    /// <summary>
    /// Guarda una universidad
    /// </summary>
    /// <param name="university">Datos de la universidad a guardar</param>
    Task<UniversityApiResponse> SaveAsync(University university);
    
    /// <summary>
    /// Actualiza una universidad
    /// </summary>
    /// <param name="universityId">Id de la universidad a actualizar</param>
    /// <param name="university">Datos de la universidad a actualizar</param>
    Task<UniversityApiResponse> UpdateAsync(int universityId, University university);
    
    /// <summary>
    /// Elimina una universidad
    /// </summary>
    /// <param name="universityId">Id de la universidad a eliminar</param>
    Task<UniversityApiResponse> DeleteAsync(int universityId);
}