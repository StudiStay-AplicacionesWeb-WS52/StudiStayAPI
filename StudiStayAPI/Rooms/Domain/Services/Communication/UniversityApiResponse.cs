using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Domain.Services.Communication;

public class UniversityApiResponse : BaseApiResponse<University>
{
    public UniversityApiResponse(string message, University resource) : base(message, resource) {}
    public UniversityApiResponse(string message) : base(message) {}
    public UniversityApiResponse(University resource) : base(resource) {}
}