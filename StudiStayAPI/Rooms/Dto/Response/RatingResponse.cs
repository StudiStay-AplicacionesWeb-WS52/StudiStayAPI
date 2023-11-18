namespace StudiStayAPI.Rooms.Dto.Response;

/// <summary>
/// Clase que se usa para mapear el response del API (lo que se devuelve al cliente en formato JSON)
/// </summary>

public class Rating
{
    public int Id { get; set; }
    public float Score { get; set; }
    public string Comment { get; set; }

    //  relationships
    User User { get; set; }
    int UserId {  get; set; }
    int RatingListId { get; set; }

}