namespace StudiStayAPI.Rooms.Dto.Response;

public class UniversityResponse
{
    public int Id { get; set; }
    public string LogoUrl { get; set; }
    public string Name { get; set; }
    public string Initials { get; set; }

    public LocationResponse Location { get; set; }
}