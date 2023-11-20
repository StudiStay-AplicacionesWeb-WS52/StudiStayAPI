using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad Post, accion de actualizar)
/// </summary>
public class UpdatePostRequest
{
    [MaxLength(80)]
    public string? Title { get; set; }
    
    [MinLength(20)]
    [MaxLength(200)]
    public string? Description { get; set; }
    
    // public string? Address { get; set; }

    [Range(3, 1000)]
    public float? Price { get; set; }
    
    // public float? Rating { get; set; }
    
    public string? ImageUrl { get; set; }

    [Required] //temporal (hasta que se implemente la autenticacion)
    public int UserId { get; set; }
    
    // public string? NearestUniversities { get; set; }

    public int? LocationId { get; set; }
}