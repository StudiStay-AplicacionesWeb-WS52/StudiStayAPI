using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication
{
    public class RatingApiResponse : BaseApiResponse<Rating>
    {
        public RatingApiResponse(string message, Rating resource) : base(message, resource) { }
        public RatingApiResponse(string message) : base(message) { }
        public RatingApiResponse(Rating resource) : base(resource) { }
    }
}
