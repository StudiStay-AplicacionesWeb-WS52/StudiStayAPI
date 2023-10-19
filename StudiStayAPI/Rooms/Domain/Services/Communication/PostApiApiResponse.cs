using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class PostApiApiResponse : BaseApiResponse<Post>
{
    public PostApiApiResponse(string message, Post resource) : base(message, resource) {}
    public PostApiApiResponse(string message) : base(message) {}
    public PostApiApiResponse(Post resource) : base(resource) {}
}