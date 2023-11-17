using AutoMapper;
using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Security.Domain.Services.Communication;
using StudiStayAPI.Security.Dto.Response;

namespace StudiStayAPI.Security.Mapping;

public class ModelToDtoProfile : Profile
{
    public ModelToDtoProfile()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<User, UserResponse>();
    }
}