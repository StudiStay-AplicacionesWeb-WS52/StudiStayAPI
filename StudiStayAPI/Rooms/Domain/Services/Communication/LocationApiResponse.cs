using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication
{
    public class LocationApiResponse : BaseApiResponse<Location>
    {
        public LocationApiResponse(string message, Location resource) : base(message, resource) { }
        public LocationApiResponse(string message) : base(message) { }
        public LocationApiResponse(Location resource) : base(resource) { }
    }
}
