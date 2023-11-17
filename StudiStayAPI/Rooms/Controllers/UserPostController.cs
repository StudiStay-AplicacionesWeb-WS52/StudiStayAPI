using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Dto.Response;

namespace StudiStayAPI.Rooms.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/users/{userId}/posts")]
public class UserPostController : ControllerBase
{
    private readonly IPostService postService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public UserPostController(IPostService postService, IMapper mapper)
    {
        this.postService = postService;
        this.mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PostResponse>> GetAllByCategoryIdAsync(int userId)
    {
        var tutorials = await postService.ListByUserIdAsync(userId);
        var response = mapper.Map<IEnumerable<Post>, IEnumerable<PostResponse>>(tutorials);
        return response;
    }
}