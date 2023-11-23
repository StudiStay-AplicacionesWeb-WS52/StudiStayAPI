namespace StudiStayAPI.Security.Domain.Services.Communication;

public class LoginResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string ImageUrl { get; set; }
    public string Token { get; set; }
    public string Phone { get; set; }
}