using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories;

public interface IReservationRepository
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
    /// Encuentra una reservacion por su id
    /// </summary>
    /// <param name="reservationId">Id de la reservacion a buscar</param>
    Task<Reservation> FindByIdAsync(int reservationId);
    
    /// <summary>
    /// Agrega una reservacion
    /// </summary>
    /// <param name="reservation">Reservacion a agregar</param>
    Task AddAsync(Reservation reservation);
    
    /// <summary>
    /// Verifica si una habitacion esta disponible en un rango de fechas
    /// </summary>
    /// <param name="postId">Id del post</param>
    /// <param name="startDate">Checkin</param>
    /// <param name="endDate">Checkout</param>
    Task<bool> isAvailableAsync(int postId, DateTime startDate, DateTime endDate);

    /// <summary>
    /// Actualiza una reservacion
    /// </summary>
    /// <param name="reservation">Reservacion a actualizar</param>
    void Update(Reservation reservation);
    
    /// <summary>
    /// Elimina una reservacion
    /// </summary>
    /// <param name="reservation">Reservation a eliminar</param>
    void Remove(Reservation reservation);
}