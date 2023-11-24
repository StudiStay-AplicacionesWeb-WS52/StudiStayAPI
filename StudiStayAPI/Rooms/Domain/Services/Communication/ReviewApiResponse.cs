using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class ReviewApiResponse : BaseApiResponse<Review>
{
    public ReviewApiResponse(string message, Review resource) : base(message, resource) {}
    public ReviewApiResponse(string message) : base(message) {}
    public ReviewApiResponse(Review resource) : base(resource) {}
}