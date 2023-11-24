using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;
using StudiStayAPI.Rooms.Dto.Response;
using StudiStayAPI.Rooms.Dto.Request;
using StudiStayAPI.Shared.Extensions;

namespace StudiStayAPI.Rooms.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly ICalificationService _calificationService;
    private readonly IMapper _mapper;
    
    //Inyeccion de dependencias
    public ReviewController(IReviewService reviewService,ICalificationService calificationService , IMapper mapper)
    {
        _reviewService = reviewService;
        _calificationService = calificationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ReviewResponse>> GetAllAsync()
    {
        // De Review a ReviewResponse
        var reviews = await _reviewService.ListAsync();

        // De Calificacion a ReviewResponse
        var califications = await _calificationService.ListAsync();

        //Crea una lista de ReviewResponse donde cada elemento es un ReviewResponse con los datos de Review y Calification
        var combinedResponses = new List<ReviewResponse>();
        
        foreach (var reviewResponse in reviews)
        {
            foreach (var calificationResponse in califications)
            {
                if (reviewResponse.CalificationId == calificationResponse.Id)
                {
                    combinedResponses.Add(new ReviewResponse
                    {
                        // Propiedades comunes con ReviewResponse
                        Date = reviewResponse.Date,
                        CalificationId = reviewResponse.CalificationId,
                        PostId = reviewResponse.PostId,
                        Valoration = calificationResponse.Valoration,
                        Comment = calificationResponse.Comment
                    });
                }
            }
        }
        
        return combinedResponses;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ReviewRequest reviewRequest)
    {
        
        //De ReviewResponse a Calification
        var calification = _mapper.Map<ReviewRequest, Calification>(reviewRequest);
        
        // Guarda la calificacion
        var resultCalification = await _calificationService.SaveAsync(calification);
        
        // Valida que el resultado sea exitoso
        if (!resultCalification.Success) return BadRequest(resultCalification.Message);
        
        reviewRequest.CalificationId = resultCalification.Resource.Id;
        
        
        // Valida que el modelo sea valido
        if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
        
        // De ReviewResponse a Review
        var review = _mapper.Map<ReviewRequest, Review>(reviewRequest);
        
        // Guarda el review
        var resultReview = await _reviewService.SaveAsync(review);
        
        // Valida que el resultado sea exitoso
        if (!resultReview.Success) return BadRequest(resultReview.Message);
        
        
        
        // De Review a ReviewResponse para mostrarlo en el response
        
        var combinedResponse = new ReviewResponse
        {
            // Propiedades comunes con ReviewResponse
            Date = review.Date,
            CalificationId = review.CalificationId,
            PostId = review.PostId,
            Valoration = calification.Valoration,
            Comment = calification.Comment
        };
        
        // Retorna el response
        return Ok(combinedResponse);
    }
}