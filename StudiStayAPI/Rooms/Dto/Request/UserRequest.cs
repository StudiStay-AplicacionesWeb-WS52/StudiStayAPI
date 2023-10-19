namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad User)
/// </summary>
public class UserRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
}