namespace StudiStayAPI.Rooms.Domain.Models;

public class RatingList
{
    public int Id { get; set; }

    public IList<Rating> Ratings { get; set; } = new List<Rating>();
    public int PostId;

}