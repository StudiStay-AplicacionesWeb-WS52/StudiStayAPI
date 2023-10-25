namespace StudiStayAPI.Rooms.Domain.Models;

public class Reservation
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; } // Precio total de la reserva
    public int StayHours { get; set; } // Horas de estadía
    public DateTime CheckInDate { get; set; } // Fecha de inicio de estadía
    public DateTime CheckOutDate { get; set; } // Fecha de finalización de estadía
    public string PaymentMethod { get; set; } // Método de pago
    
    //relaciones
    public int UserId { get; set; }
    public User User { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
}
