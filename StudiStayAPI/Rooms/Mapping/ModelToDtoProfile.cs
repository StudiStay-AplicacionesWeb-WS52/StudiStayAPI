using AutoMapper;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Dto.Response;

namespace StudiStayAPI.Rooms.Mapping
{
    /// <summary>
    /// Perfil de Automapper para mapear desde la Entidad al Dto (response)
    /// </summary>
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            // Mappings for Post
            CreateMap<Post, PostResponse>();

            // Mappings for University
            CreateMap<University, UniversityResponse>();

            // Mappings for Reservation
            CreateMap<Reservation, ReservationResponse>();

            // Mappings for Location
            CreateMap<Location, LocationResponse>();

    }
}
