using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication
{
    public class RatingListApiResponse : BaseApiResponse<int>
    {
        public RatingListApiResponse(string message, int resource) : base(message, resource) { }
        public RatingListApiResponse(string message) : base(message) { }
        public RatingListApiResponse(int resource) : base(resource) { }
    }
}

