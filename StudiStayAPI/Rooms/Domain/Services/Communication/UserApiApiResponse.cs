using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class UserApiApiResponse : BaseApiResponse<User>
{
    public UserApiApiResponse(string message, User resource) : base(message, resource) {}
    public UserApiApiResponse(string message) : base(message) {}
    public UserApiApiResponse(User resource) : base(resource) {}
}