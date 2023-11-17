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
public class PostController : ControllerBase
{
    private readonly IPostService postService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public PostController(IPostService postService, IMapper mapper)
    {
        this.postService = postService;
        this.mapper = mapper;
    }
    
    //endpoint para obtener todos los posts
    [HttpGet]
    public async Task<IEnumerable<PostResponse>> GetAllAsync()
    {
        var posts = await postService.ListAsync();
        return mapper.Map<IEnumerable<Post>, IEnumerable<PostResponse>>(posts);
    }
    
    //endpoint para obtener un post por id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await postService.GetByIdAsync(id);
        
        if (!result.Success) return NotFound(result.Message);
        
        var postResponse = mapper.Map<Post, PostResponse>(result.Resource);
        return Ok(postResponse);
    }

    //endpoint para crear un post
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] PostRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var post = mapper.Map<PostRequest, Post>(request);
        var result = await postService.SaveAsync(post);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Post, PostResponse>(result.Resource);
        return Ok(response);
    }

    //endpoint para actualizar un post
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdatePostRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var post = mapper.Map<UpdatePostRequest, Post>(request);
        var result = await postService.UpdateAsync(id, post);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Post, PostResponse>(result.Resource);
        return Ok(response);
    }

    //endpoint para eliminar un post
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await postService.DeleteAsync(id);
 
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Post, PostResponse>(result.Resource);
        return Ok(response);
    }
}