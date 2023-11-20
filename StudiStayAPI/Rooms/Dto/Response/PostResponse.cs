using StudiStayAPI.Security.Dto.Response;
using System.Collections.Generic;

namespace StudiStayAPI.Rooms.Dto.Response
{
    /// <summary>
    /// Clase que se usa para mapear el response del API (lo que se devuelve al cliente en formato JSON)
    /// </summary>
    public class PostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public UserResponse User { get; set; }

        // Add properties based on the changes in the Post model
        public IList<ReservationResponse> Reservations { get; set; } = new List<ReservationResponse>();
        public LocationResponse Location { get; set; }
    }
}
