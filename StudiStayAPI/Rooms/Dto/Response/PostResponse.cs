namespace StudiStayAPI.Rooms.Dto.Response;

/// <summary>
/// Clase que se usa para mapear el response del API (lo que se devuelve al cliente en formato JSON)
/// </summary>
public class PostResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //  public string Address { get; set; }
    public float Price { get; set; }
    //  public float Rating { get; set; }
    public string ImageUrl { get; set; }
    public UserResponse User { get; set; }
    //  public string NearestUniversities { get; set; }
}