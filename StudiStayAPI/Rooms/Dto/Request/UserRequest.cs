using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad User)
/// </summary>
public class UserRequest
{
    [Required]
    [MaxLength(80)]
    public string FullName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Password { get; set; }
    
    [Required]
    public string Phone { get; set; }
  
    [Required]
    public string Role { get; set; }
    
    public string ImageUrl { get; set; }
}