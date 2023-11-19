namespace StudiStay.API.Rent.Domain.Models;

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