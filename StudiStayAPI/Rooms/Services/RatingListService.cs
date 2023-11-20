using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

/// <summary>
/// Clase que implementa la interfaz IRatingListService
/// </summary>
public class RatingListService : IRatingListService
{
    public RatingListService(IRatingListRepository ratingListRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.ratingListRepository = ratingListRepository;
        this.postRepository = postRepository;
    }

    public async Task<IEnumerable<RatingList>> ListAsync()
    {
        return await ratingListRepository.ListAsync();
    }

    public async Task<RatingListApiResponse> GetByIdAsync(int ratingListId)
    {
        var existingRatingList = await ratingListRepository.FindByIdAsync(ratingListId);
        if (existingRatingList == null) return new RatingListApiResponse("This post doesn't exist or doesn't contain any reviews");
        return new RatingListApiResponse(existingRatingList);
    }

    public async Task<IEnumerable<RatingList>> ListByPostIdAsync(int postId)
    {
        return await ratingListRepository.FindByUserIdAsync(userId);
    }

    public async Task<RatingListApiResponse> GetByPostIdAsync(int postId)
    {
        var existingRatingList = await ratingListRepository.FindByPostIdAsync(postId);
        if (existingRatingList == null) return new RatingListApiResponse("This post doesn't exist or doesn't contain any reviews");
        return new RatingListApiResponse(existingRatingList);
    }

    public async Task<RatingListApiResponse> SaveAsync(RatingList ratingList)
    {
        //valida si existe el postId
        var existingPost = await postRepository.FindByPostIdAsync(ratingList.PostId);
        if (existingPost == null) return new RatingListApiResponse("Invalid Post");

        try
        {
            //guarda el RatingList
            await RatingListRepository.AddAsync(RatingList);
            //completa la transaccion
            await unitOfWork.CompleteAsync();
            //retorna el RatingList como response
            return new RatingListApiResponse(ratingList);
        }
        catch (Exception e)
        {
            return new RatingListApiResponse($"An error occurred while saving the ratingList: {e.Message}");
        }
    }

}