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
public class ReservationController : ControllerBase
{
    private readonly IReservationService reservationService;
    private readonly IMapper mapper;
    
    //inyeccion de dependencias
    public ReservationController(IReservationService reservationService, IMapper mapper)
    {
        this.reservationService = reservationService;
        this.mapper = mapper;
    }
    
    [HttpGet("user/{id}")]
    public async Task<IEnumerable<ReservationResponse>> GetAllByUserIdAsync(int id)
    {
        var reservations = await reservationService.ListByUserIdAsync(id);
        return mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResponse>>(reservations);
    }
    
    [HttpGet("post/{id}")]
    public async Task<IEnumerable<ReservationResponse>> GetAllByPostIdAsync(int id)
    {
        var reservations = await reservationService.ListByPostIdAsync(id);
        return mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResponse>>(reservations);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ReservationRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var reservation = mapper.Map<ReservationRequest, Reservation>(request);
        var result = await reservationService.SaveAsync(reservation);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Reservation, ReservationResponse>(result.Resource);
        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateReservationRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        var reservation = mapper.Map<UpdateReservationRequest, Reservation>(request);
        var result = await reservationService.UpdateAsync(id, reservation);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Reservation, ReservationResponse>(result.Resource);
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await reservationService.DeleteAsync(id);
        
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<Reservation, ReservationResponse>(result.Resource);
        return Ok(response);
    }
}