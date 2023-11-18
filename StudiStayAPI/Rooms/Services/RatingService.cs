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

    public async Task<RatingApiResponse> GetByIdAsync(int ratingId)
    {
        var existingRating = await ratingRepository.FindByIdAsync(ratingId);
        if (existingRating == null) return new RatingApiResponse("Rating not found.");
        return new RatingApiResponse(existingRating);
    }

    public async Task<IEnumerable<Rating>> ListByUserIdAsync(int userId)
    {
        return await ratingRepository.FindByUserIdAsync(userId);
    }

    public async Task<RatingApiResponse> SaveAsync(Rating rating)
    {
        //valida el userId
        var existingRating = await ratingRepository.FindByIdAsync(rating.RatingId);
        if (existingRating == null) return new RatingApiResponse("Invalid Rating");
        
        //valida la dirección que no se repita
        var existingRatingWithTitle = await ratingRepository.FindByTitleAsync(Rating.Title);
        if (existingRatingWithTitle != null) return new RatingApiResponse("Rating title already exists.");
        
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
        
        //valida si el titulo ya existe y no es el mismo Rrating
        var existingRatingWithTitle = await ratingRepository.FindByTitleAsync(rating.Title);
        if (existingRatingWithTitle != null && existingRatingWithTitle.Id != existingRating.Id) 
            return new RatingApiResponse("Rating title already exists.");
        
        //modifica el Rating
        existingRating.Title = Rating.Title ?? existingRating.Title;
        existingPost.Description = post.Description ?? existingPost.Description;
        existingPost.Price = post.Price;
        existingPost.Address = post.Address ?? existingPost.Address;
        existingPost.Rating = post.Rating;
        existingPost.ImageUrl = post.ImageUrl ?? existingPost.ImageUrl;
        existingPost.NearestUniversities = post.NearestUniversities ?? existingPost.NearestUniversities;

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