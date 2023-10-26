namespace StudiStayAPI.Rooms.Dto.Request;

public class UpdateReservationRequest
{
    public DateTime? CheckInDate { get; set; } 
    public DateTime? CheckOutDate { get; set; }
    public string? PaymentMethod { get; set; } 
    public int UserId { get; set; }
    public int PostId { get; set; }
}