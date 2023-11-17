using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string FullName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Role { get; set; }
    public string? ImageUrl { get; set; }
}