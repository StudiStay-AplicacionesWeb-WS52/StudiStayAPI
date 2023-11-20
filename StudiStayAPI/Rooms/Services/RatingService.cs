using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

/// <summary>
/// Clase que implementa la interfaz IRatingService
/// </summary>
public class RatingService : IRatingService
{
    public RatingService(IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.ratingRepository = ratingRepository
    }

    public async Task<IEnumerable<Rating>> ListAsync()
    {
        return await ratingRepository.ListAsync();
    }

    public async Task<IEnumerable<Rating>> ListByRatingListIdAsync(int ratingListId)
        {
            return await ratingRepository.FindByRatingListIdAsync(ratingListId);
        }

    

    public async Task<RatingApiResponse> GetByIdAsync(int ratingId)
    {
        var existingRating = await ratingRepository.FindByIdAsync(ratingId);
        if (existingRating == null) return new RatingApiResponse("Rating not found.");
        return new RatingApiResponse(existingRating);
    }


    public async Task<RatingApiResponse> SaveAsync(Rating rating)
    {
        //valida que el usuario sea real 
        var existingUser = await userRepository.FindByIdAsync(rating.UserId);
        if (existingUser == null) return new RatingApiResponse("this user doesn't exist");

        //valida que exista la lista de ratings
        var existingRatingList = await ratingListRepository.FindByIdAsync(rating.ratingListId);
        if (existingRatingList == null) return new RatingApiResponse("this post doesn't exist");
        
        //valida que el usuario y la lista de reseñas no se repitan al mimsmo tiempo
        var existingRatingWithUserAndRatingList = await ratingRepository.FindByUserIdAndRatingListIdAsync(Rating.UserId,Rating.ratingListId);
        if (existingRatingWithUserAndRatingList != null) return new RatingApiResponse("The same user cannot post new reviews under the same post");
        
        try
        {
            //guarda el Rating
            await RatingRepository.AddAsync(rating);
            //completa la transaccion
            await unitOfWork.CompleteAsync();
            //retorna el rating como response
            return new RatingApiResponse(rating);
        }
        catch (Exception e)
        {
            return new RatingApiResponse($"An error occurred while saving the rating: {e.Message}");
        }
    }

    public async Task<RatingApiResponse> UpdateAsync(int ratingId, Rating rating)
    {
        //valida si existe el rating
        var existingRating = await ratingRepository.FindByIdAsync(ratingId);
        if (existingRating == null) return new RatingApiResponse("Rating not found.");
        
        //valida si existe el userId
        var existingUser = await userRepository.FindByIdAsync(rating.UserId);
        if (existingUser == null) return new RatingApiResponse("Invalid User");
        
        //valida que exista la lista de ratings
        var existingRatingList = await ratingListRepository.FindByIdAsync(rating.ratingListId);
        if (existingRatingList == null) return new RatingApiResponse("this post doesn't exist");
        
        //valida que el usuario y la lista de reseñas no se repitan al mimsmo tiempo
        var existingRatingWithUserAndRatingList = await ratingRepository.FindByUserIdAndRatingListIdAsync(Rating.UserId,Rating.ratingListId);
        if (existingRatingWithUserAndRatingList != null) return new RatingApiResponse("The same user cannot post new reviews under the same post");
                
        //modifica el Rating
        existingRating.Score = Rating.Score ?? existingRating.Score;
        existingRating.Comment = Rating.Comment ?? existingRating.Comment;

        try
        {
            ratingRepository.Update(existingRating);
            await unitOfWork.CompleteAsync();
            return new RatingApiResponse(existingRating);
        }
        catch (Exception e)
        {
            return new RatingApiResponse($"An error occurred while updating the Rating: {e.Message}");
        }
    }

    public async Task<RatingApiResponse> DeleteAsync(int ratingId)
    {
        //valida si existe el rating
        var existingRating = await ratingRepository.FindByIdAsync(ratingId);
        if (existingRating == null) return new RatingApiResponse("Rating not found.");

        try
        {
            ratingRepository.Remove(existingRating);
            await unitOfWork.CompleteAsync();
            return new RatingApiResponse(existingRating);
        }
        catch (Exception e)
        {
            return new RatingApiResponse($"An error occurred while deleting the rating: {e.Message}");
        }
    }

}