using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Security.Domain.Services;
using StudiStayAPI.Security.Domain.Services.Communication;
using StudiStayAPI.Security.Dto.Response;

namespace StudiStayAPI.Security.Controller;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await userService.LoginAsync(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await userService.ListAsync();
        var resources = mapper.Map<IEnumerable<User>, IEnumerable<UserResponse>>(users);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await userService.GetByIdAsync(id);
        var resource = mapper.Map<User, UserResponse>(user);
        return Ok(resource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserRequest request)
    {
        await userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
        
    }
}