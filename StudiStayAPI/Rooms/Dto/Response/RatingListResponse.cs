namespace StudiStayAPI.Rooms.Dto.Response;

/// <summary>
/// Clase que se usa para mapear el response del API (lo que se devuelve al cliente en formato JSON)
/// </summary>

public class RatingList
{
    public int Id { get; set; }

    public IList<Rating> Ratings { get; set; } = new List<Rating>();
    public int PostId;

}