using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Dto.Request;
using StudiStayAPI.Rooms.Dto.Response;
using StudiStayAPI.Shared.Extensions;

namespace StudiStayAPI.Rooms.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public UserController(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }
    
    //endpoint para obtener todos los usuarios
    [HttpGet]
    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        //obtiene todos los usuarios
        var users = await userService.ListAsync();
        //mapea los usuarios al dto UserResponse
        return mapper.Map<IEnumerable<User>, IEnumerable<UserResponse>>(users);
    }
    
    //endpoint para crear un usuario
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserRequest request)
    {
        //valida que el modelo sea valido
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        //mapea el dto UserRequest al modelo User
        var user = mapper.Map<UserRequest, User>(request);
        //guarda el usuario
        var result = await userService.SaveAsync(user);
        
        //valida que el resultado sea exitoso
        if (!result.Success) return BadRequest(result.Message);
        
        //mapea el modelo User al dto UserResponse para mostrarlo en el response (JSON)
        var response = mapper.Map<User, UserResponse>(result.Resource);
        
        //retorna el response
        return Ok(response);
    }

    //endpoint para actualizar un usuario
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
 
        var user = mapper.Map<UserRequest, User>(request);
        var result = await userService.UpdateAsync(id, user);
 
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<User, UserResponse>(result.Resource);
        return Ok(response);
    }
    
    //endpoint para eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await userService.DeleteAsync(id);
        if (!result.Success) return BadRequest(result.Message);
 
        var response = mapper.Map<User, UserResponse>(result.Resource);
        return Ok(response);
    }
}