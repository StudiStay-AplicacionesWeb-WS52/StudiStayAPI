using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad Post)
/// </summary>
public class PostRequest
{
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    
    [Required]
    [MinLength(20)]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    public string Address { get; set; }

    [Required]
    [Range(3, 1000)]
    public float Price { get; set; }
    
    public float Rating { get; set; }
    
    [Required]
    public string NearestUniversity { get; set; }
    
    [Required]
    public int UserId { get; set; }
}