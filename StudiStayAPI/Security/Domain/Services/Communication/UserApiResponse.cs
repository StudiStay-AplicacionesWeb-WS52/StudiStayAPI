using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Security.Domain.Services.Communication;

public class UserApiResponse : BaseApiResponse<User>
{
    public UserApiResponse(string message, User resource) : base(message, resource) {}
    public UserApiResponse(string message) : base(message) {}
    public UserApiResponse(User resource) : base(resource) {}
}