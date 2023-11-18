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

public class LocationController : ControllerBase{
    private readonly ILocationService locationService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public LocationController(ILocationService locationService, IMapper mapper)
    {
        this.locationService = locationService;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<LocationResponse>> GetAllAsync()
    {
        var locations = await LocationService.ListAsync();
        return mapper.Map<IEnumerable<Location>, IEnumerable<LocationResponse>>(locations);
    }

    // get the Location by it's id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await LocationService.GetByIdAsync(id);
        
        if (!result.Success) return NotFound(result.Message);
        
        var locationResponse = mapper.Map<Location, LocationResponse>(result.Resource);
        return Ok(locationResponse);
    }

    // Create a Location

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] LocationRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var location = mapper.Map<LocationRequest, Location>(request);
        var result = await locationService.SaveAsync(location);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Location, LocationResponse>(result.Resource);
        return Ok(response);
    }

    // for updating the location

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateLocationRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var location = mapper.Map<UpdateLocationRequest, Location>(request);
        var result = await locationService.UpdateAsync(id, location);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Location, LocationResponse>(result.Resource);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await locationService.DeleteAsync(id);
 
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Location, LocationResponse>(result.Resource);
        return Ok(response);
    }
}

