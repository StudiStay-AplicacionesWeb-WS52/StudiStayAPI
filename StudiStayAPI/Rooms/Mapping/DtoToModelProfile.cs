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
        //mapeo de Dto a Entidad para Post
        CreateMap<PostRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();
        //mapeo de Dto a Entidad para University
        CreateMap<UniversityRequest, University>();
        CreateMap<UpdateUniversityRequest, University>();
        //mapeo de Dto a Entidad para Reservation
        CreateMap<ReservationRequest, Reservation>();
        CreateMap<UpdateReservationRequest, Reservation>();
    }
}