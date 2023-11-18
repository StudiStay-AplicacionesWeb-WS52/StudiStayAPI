using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Security.Domain.Services.Communication;

public class LoginRequest
{
    [Required] 
    public string Email { get; set; }
    
    [Required] 
    public string Password { get; set; }
}