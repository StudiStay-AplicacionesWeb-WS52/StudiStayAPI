namespace StudiStayAPI.Rooms.Dto.Request;

public class UpdateUniversityRequest
{
    public string? LogoUrl { get; set; }
    public string? Name { get; set; }
    public string? Initials { get; set; }

    public int? LocationId { get; set; } 
}