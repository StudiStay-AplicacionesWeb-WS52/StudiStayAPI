namespace StudiStayAPI.Rooms.Domain.Models;

/// <summary>
/// Entidad que representa a un post
/// </summary>
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public float Price { get; set; }
    public float Rating { get; set; }
    public string NearestUniversity { get; set; }
    
    //relaciones
    public int UserId { get; set; }
    public User User { get; set; }
}
