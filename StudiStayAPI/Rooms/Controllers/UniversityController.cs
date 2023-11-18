using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Dto.Request;
using StudiStayAPI.Rooms.Dto.Response;
using StudiStayAPI.Shared.Extensions;

namespace StudiStayAPI.Rooms.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UniversityController : ControllerBase
{
    private readonly IUniversityService universityService;
    private readonly IMapper mapper;

    //inyeccion de dependencias
    public UniversityController(IUniversityService universityService, IMapper mapper)
    {
        this.universityService = universityService;
        this.mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UniversityResponse>> GetAllAsync()
    {
        var universities = await universityService.ListAsync();
        //mapea las universidades al dto UniversityResponse
        return mapper.Map<IEnumerable<University>, IEnumerable<UniversityResponse>>(universities);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UniversityRequest request)
    {
        //valida que el modelo sea valido
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        //mapea el dto UniversityRequest al modelo University
        var university = mapper.Map<UniversityRequest, University>(request);
        //guarda la universidad
        var result = await universityService.SaveAsync(university);
        
        //valida que el resultado sea exitoso
        if (!result.Success) return BadRequest(result.Message);
        
        //mapea el modelo University al dto UniversityResponse para mostrarlo en el response (JSON)
        var response = mapper.Map<University, UniversityResponse>(result.Resource);
        
        //retorna el response
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateUniversityRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
 
        var university = mapper.Map<UpdateUniversityRequest, University>(request);
        var result = await universityService.UpdateAsync(id, university);
 
        if (!result.Success) return BadRequest(result.Message);
        
        var response = mapper.Map<University, UniversityResponse>(result.Resource);
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await universityService.DeleteAsync(id);
        if (!result.Success) return BadRequest(result.Message);
 
        var response = mapper.Map<University, UniversityResponse>(result.Resource);
        return Ok(response);
    }
}