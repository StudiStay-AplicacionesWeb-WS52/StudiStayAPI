namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad Post)
/// </summary>
public class PostRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public float Price { get; set; }
    public float Rating { get; set; }
    public string NearestUniversity { get; set; }
    public int UserId { get; set; }
}