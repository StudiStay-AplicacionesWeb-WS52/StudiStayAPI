namespace StudiStayAPI.Security.Domain.Services.Communication;

public class UpdateUserRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ImageUrl { get; set; }
}