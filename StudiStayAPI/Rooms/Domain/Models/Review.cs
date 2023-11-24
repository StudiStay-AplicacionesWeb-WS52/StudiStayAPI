namespace StudiStayAPI.Rooms.Domain.Models;

public class Review
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    
    // Relationships
    public int CalificationId { get; set; }
    public Calification Calification { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
}