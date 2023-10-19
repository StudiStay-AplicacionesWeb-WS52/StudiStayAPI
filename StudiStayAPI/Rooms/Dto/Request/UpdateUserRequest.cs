using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad User, accion de actualizar)
/// </summary>
public class UpdateUserRequest
{
    [MaxLength(80)]
    public string? FullName { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [MinLength(5)]
    [MaxLength(20)]
    public string? Password { get; set; }
    
    public string? Phone { get; set; }
}