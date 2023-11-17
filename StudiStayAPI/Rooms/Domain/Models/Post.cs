using StudiStayAPI.Security.Domain.Models;

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
    public string ImageUrl { get; set; }
    public string NearestUniversities { get; set; } //JSON
    
    //relaciones
    public int UserId { get; set; }
    public User User { get; set; }
    public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
}
