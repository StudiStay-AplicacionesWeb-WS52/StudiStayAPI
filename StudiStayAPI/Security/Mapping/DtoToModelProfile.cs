using AutoMapper;
using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Security.Domain.Services.Communication;

namespace StudiStayAPI.Security.Mapping;

public class DtoToModelProfile : Profile
{
    public DtoToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    //se ignora la propiedad si el valor es nulo o vacio
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                   
                    return true;
                }
            ));
    }


}