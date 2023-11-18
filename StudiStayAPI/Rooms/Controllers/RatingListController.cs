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

public class RatingListController : ControllerBase{
    private readonly IRatingListService ratingListService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public RatingListController(ILocationService ratingListService, IMapper mapper)
    {
        this.ratingListService = ratingListService;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<RatingResponse>> GetAllAsync()
    {
        var ratingLists = await RatingListService.ListAsync();
        return mapper.Map<IEnumerable<RatingList>, IEnumerable<RatingListResponse>>(ratingLists);
    }

    //endpoint para obtener un post por id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await ratingListService.GetByIdAsync(id);
        
        if (!result.Success) return NotFound(result.Message);
        
        var ratingListResponse = mapper.Map<RatingList, RatingListResponse>(result.Resource);
        return Ok(ratingListResponse);
    }

    //endpoint para crear un post
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RatingListResponse request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var ratingList = mapper.Map<ratingListRequest, RatingList>(request);
        var result = await postService.SaveAsync(rating);
        
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