using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class ReservationApiResponse : BaseApiResponse<Reservation>
{
    public ReservationApiResponse(string message, Reservation resource) : base(message, resource) {}
    public ReservationApiResponse(string message) : base(message) {}
    public ReservationApiResponse(Reservation resource) : base(resource) {}
}