using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class CalificationApiResponse : BaseApiResponse<Calification>
{
    public CalificationApiResponse(string message, Calification resource) : base(message, resource) {}
    public CalificationApiResponse(string message) : base(message) {}
    public CalificationApiResponse(Calification resource) : base(resource) {}
}