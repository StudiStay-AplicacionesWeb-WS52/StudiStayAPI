namespace StudiStayAPI.Rooms.Dto.Response;

public class ReviewResponse
{
    public DateTime Date { get; set; }
    
    public int PostId { get; set; }
    
    public int CalificationId { get; set; }
    
    public int Valoration { get; set; }
    
    public string Comment { get; set; }
}