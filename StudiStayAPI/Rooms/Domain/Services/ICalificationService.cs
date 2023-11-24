using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

public interface ICalificationService
{
    /// <summary>
    /// Obtiene una lista de todas las calificaciones
    /// </summary>
    Task<IEnumerable<Calification>> ListAsync();
    
    /// <summary>
    /// Guarda una calificacion
    /// </summary>
    Task<CalificationApiResponse> SaveAsync(Calification calification);
    
    /// <summary>
    /// Elimina una calificacion
    /// </summary>
    /// <param name="id">Id de la calificacion a eliminar</param>
    Task<CalificationApiResponse> DeleteAsync(int id);
}