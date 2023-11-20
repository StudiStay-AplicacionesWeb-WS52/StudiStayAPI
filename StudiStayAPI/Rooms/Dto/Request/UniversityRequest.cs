using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

public class UniversityRequest
{
    [Required]
    public string LogoUrl { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Initials { get; set; }

    [Required]
    public int LocationId { get; set; }
}