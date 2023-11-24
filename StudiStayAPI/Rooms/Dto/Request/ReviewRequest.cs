using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

public class ReviewRequest
{
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public int PostId { get; set; }
    
    // Calification Attributes
    [Required]
    public int CalificationId { get; set; }
    
    [Required]
    public int Valoration { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Comment { get; set; }
    //

}