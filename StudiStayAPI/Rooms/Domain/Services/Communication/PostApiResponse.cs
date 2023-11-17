using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class PostApiResponse : BaseApiResponse<Post>
{
    public PostApiResponse(string message, Post resource) : base(message, resource) {}
    public PostApiResponse(string message) : base(message) {}
    public PostApiResponse(Post resource) : base(resource) {}
}