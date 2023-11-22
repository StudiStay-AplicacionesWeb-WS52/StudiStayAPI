using AutoMapper;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Dto.Request;

namespace StudiStayAPI.Rooms.Mapping;

/// <summary>
/// Perfil de Automapper para mapear desde un Dto (request) a la entidad correspondiente
/// </summary>
public class DtoToModelProfile : Profile
{
    public DtoToModelProfile()
    {
        // Mappings for Post
        CreateMap<PostRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();

        // Mappings for University
        CreateMap<UniversityRequest, University>();
        CreateMap<UpdateUniversityRequest, University>();

        // Mappings for Reservation
        CreateMap<ReservationRequest, Reservation>();
        CreateMap<UpdateReservationRequest, Reservation>();

        // Mappings for Location
        CreateMap<LocationRequest, Location>();
        CreateMap<UpdateLocationRequest, Location>();
    }
}
