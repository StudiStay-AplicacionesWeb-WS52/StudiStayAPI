using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

public class ReservationRequest
{
    [Required]
    public DateTime CheckInDate { get; set; } 
    
    [Required]
    public DateTime CheckOutDate { get; set; }
    
    [Required]
    public string PaymentMethod { get; set; } 
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int PostId { get; set; }
}