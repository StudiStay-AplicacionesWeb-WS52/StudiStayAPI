using AutoMapper;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Dto.Response;

namespace StudiStayAPI.Rooms.Mapping;

/// <summary>
/// Perfil de Automapper para mapear desde la Entidad al Dto (response)
/// </summary>
public class ModelToDtoProfile : Profile
{
    public ModelToDtoProfile()
    {
        //mapeo de Entidad a Dto para User
        CreateMap<User, UserResponse>();
        //mapeo de Entidad a Dto para Post
        CreateMap<Post, PostResponse>();
        //mapeo de Entidad a Dto para University
        CreateMap<University, UniversityResponse>();
        //mapeo de Entidad a Dto para Reservation
        CreateMap<Reservation, ReservationResponse>();
    }
}