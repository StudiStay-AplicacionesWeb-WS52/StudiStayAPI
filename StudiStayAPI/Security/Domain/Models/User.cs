using System.Text.Json.Serialization;
using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Security.Domain.Models;

/// <summary>
/// Entidad que representa a un usuario
/// </summary>
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string Phone { get; set; }
    public string ImageUrl { get; set; }
    public string Role { get; set; }
    
    //relaciones
    public IList<Post> Posts { get; set; } = new List<Post>();
    public IList<Reservation> Reservations { get; set; } = new List<Reservation>();
}