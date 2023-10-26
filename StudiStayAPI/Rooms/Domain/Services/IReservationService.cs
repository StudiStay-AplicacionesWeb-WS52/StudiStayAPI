using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services;

public interface IReservationService
{
    /// <summary>
    /// Obtiene todas las reservaciones de un post
    /// </summary>
    Task<IEnumerable<Reservation>> ListByPostIdAsync(int postId);
    
    /// <summary>
    /// Obtiene todas las reservaciones de un usuario
    /// </summary>
    /// <param name="userId">Id del usuario</param>
    Task<IEnumerable<Reservation>> ListByUserIdAsync(int userId);
    
    /// <summary>
    /// Obtiene una reservacion por id
    /// </summary>
    /// <param name="reservationId">Id de la reservacion a buscar</param>
    Task<ReservationApiResponse> GetByIdAsync(int reservationId);
    
    /// <summary>
    /// Guarda una reservacion
    /// </summary>
    /// <param name="reservation">Reservacion a agregar</param>
    Task<ReservationApiResponse> SaveAsync(Reservation reservation);

    /// <summary>
    /// Actualiza una reservacion
    /// </summary>
    /// <param name="reservationId">Reservacion a actualizar</param>
    /// <param name="reservation">Datos de la reservacion a actualizar</param>
    Task<ReservationApiResponse> UpdateAsync(int reservationId, Reservation reservation);
    
    /// <summary>
    /// Elimina una reservacion
    /// </summary>
    /// <param name="reservationId">Id de la reservacion a eliminar</param>
    Task<ReservationApiResponse> DeleteAsync(int reservationId);
}