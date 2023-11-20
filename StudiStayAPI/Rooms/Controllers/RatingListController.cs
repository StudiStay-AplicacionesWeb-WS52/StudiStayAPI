using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudiStayAPI.Rooms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class RatingListController : ControllerBase
    {
        private readonly IRatingListService ratingListService;
        private readonly IMapper mapper;

        public RatingListController(IRatingListService ratingListService, IMapper mapper)
        {
            this.ratingListService = ratingListService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RatingListResponse>> GetAllAsync()
        {
            var ratingLists = await ratingListService.ListAsync();
            return mapper.Map<IEnumerable<RatingList>, IEnumerable<RatingListResponse>>(ratingLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await ratingListService.GetByIdAsync(id);

            if (!result.Success) return NotFound(result.Message);

            var ratingListResponse = mapper.Map<RatingList, RatingListResponse>(result.Resource);
            return Ok(ratingListResponse);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetByPostIdAsync(int postId)
        {
            var result = await ratingListService.GetByPostIdAsync(postId);

            if (!result.Success) return NotFound(result.Message);

            var ratingListResponse = mapper.Map<RatingList, RatingListResponse>(result.Resource);
            return Ok(ratingListResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RatingListResponse request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var ratingList = mapper.Map<RatingListResponse, RatingList>(request);
            var result = await ratingListService.SaveAsync(ratingList);

            if (!result.Success) return BadRequest(result.Message);

            var response = mapper.Map<RatingList, RatingListResponse>(result.Resource);
            return Ok(response);
        }
    }
}
