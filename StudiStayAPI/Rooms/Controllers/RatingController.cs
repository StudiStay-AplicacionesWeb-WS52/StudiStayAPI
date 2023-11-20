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

public class RatingController : ControllerBase{
    private readonly IRatingService ratingService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public ratingController(IratingService ratingService, IMapper mapper)
    {
        this.ratingService = ratingService;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<RatingResponse>> GetAllAsync()
    {
        var ratings = await RatingService.ListAsync();
        return mapper.Map<IEnumerable<Rating>, IEnumerable<RatingResponse>>(ratings);
    }

    //endpoint para obtener una reseña por id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await ratingService.GetByIdAsync(id);
        
        if (!result.Success) return NotFound(result.Message);
        
        var ratingResponse = mapper.Map<Rating, RatingResponse>(result.Resource);
        return Ok(ratingResponse);
    }

    //endpoint para obtener todas las reseñas de un post
   [HttpGet("ratingList/{ratingListId}")]
    public async Task<IActionResult> GetByRatingListAsync(int ratingListId)
    {
        var result = await ratingService.ListByRatingListIdAsync(ratingListId);

        if (!result.Any()) return NotFound($"No ratings found for rating list with ID {ratingListId}.");

        var ratingResponse = mapper.Map<IEnumerable<Rating>, IEnumerable<RatingResponse>>(result);
        return Ok(ratingResponse);
    }
    
    //endpoint para crear una reseña post
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RatingResponse request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var rating = mapper.Map<RatingRequest, Rating>(request);
        var result = await ratingService.SaveAsync(rating);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Rating, RatingResponse>(result.Resource);
        return Ok(response);
    }

    //endpoint para actualizar un post
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateRatingRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var post = mapper.Map<UpdateRatingRequest, Rating>(request);
        var result = await ratingService.UpdateAsync(id, rating);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Rating, RatingResponse>(result.Resource);
        return Ok(response);
    }

    //endpoint para eliminar un post
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await ratingpostService.DeleteAsync(id);
 
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Rating, RatingResponse>(result.Resource);
        return Ok(response);
    }

  
}