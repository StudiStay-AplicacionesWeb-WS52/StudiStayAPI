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
    public RatingListService(IRatingListRepository ratingListRepository, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.ratingListRepository = ratingListRepository
    }

    public async Task<IEnumerable<RatingList>> ListAsync()
    {
        return await ratingListRepository.ListAsync();
    }

    public async Task<RatingListApiResponse> GetByIdAsync(int ratingListId)
    {
        var existingRatingList = await ratingListRepository.FindByIdAsync(ratingListId);
        if (existingRatingList == null) return new RatingListApiResponse("RatingList not found.");
        return new RatingListApiResponse(existingRatingList);
    }

    public async Task<IEnumerable<RatingList>> ListByUserIdAsync(int userId)
    {
        return await ratingListRepository.FindByUserIdAsync(userId);
    }

    public async Task<RatingListApiResponse> SaveAsync(RatingList ratingList)
    {
        //valida el userId
        var existingRatingList = await ratingListRepository.FindByIdAsync(ratingList.RatingListId);
        if (existingRatingList == null) return new RatingListApiResponse("Invalid RatingList");
        
        //valida la dirección que no se repita
        var existingRatingListWithTitle = await ratingListRepository.FindByTitleAsync(RatingList.Title);
        if (existingRatingListWithTitle != null) return new RatingListApiResponse("RatingList title already exists.");
        
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

    public async Task<RatingListApiResponse> UpdateAsync(int ratingListId, RatingList ratingList)
    {
        //valida si existe el ratingList
        var existingRatingList = await ratingListRepository.FindByIdAsync(ratingListId);
        if (existingRatingList == null) return new RatingListApiResponse("RatingList not found.");
        
        //valida si existe el userId
        var existingUser = await userRepository.FindByIdAsync(ratingList.UserId);
        if (existingUser == null) return new RatingListApiResponse("Invalid User");
        
        //valida si el titulo ya existe y no es el mismo RRatingList
        var existingRatingListWithTitle = await ratingListRepository.FindByTitleAsync(ratingList.Title);
        if (existingRatingListWithTitle != null && existingRatingListWithTitle.Id != existingRatingList.Id) 
            return new RatingListApiResponse("RatingList title already exists.");
        
        //modifica el RatingList
        existingRatingList.Title = RatingList.Title ?? existingRatingList.Title;
        existingPost.Description = post.Description ?? existingPost.Description;
        existingPost.Price = post.Price;
        existingPost.Address = post.Address ?? existingPost.Address;
        existingPost.RatingList = post.RatingList;
        existingPost.ImageUrl = post.ImageUrl ?? existingPost.ImageUrl;
        existingPost.NearestUniversities = post.NearestUniversities ?? existingPost.NearestUniversities;

        try
        {
            RatingListRepository.Update(existingRatingList);
            await unitOfWork.CompleteAsync();
            return new RatingListApiResponse(existingRatingList);
        }
        catch (Exception e)
        {
            return new RatingListApiResponse($"An error occurred while updating the RatingList: {e.Message}");
        }
    }

    public async Task<RatingListApiResponse> DeleteAsync(int ratingListId)
    {
        //valida si existe el RatingList
        var existingRatingList = await ratingListRepository.FindByIdAsync(ratingListId);
        if (existingRatingList == null) return new RatingListApiResponse("RatingList not found.");

        try
        {
            ratingListRepository.Remove(existingRatingList);
            await unitOfWork.CompleteAsync();
            return new RatingListApiResponse(existingRatingList);
        }
        catch (Exception e)
        {
            return new RatingListApiResponse($"An error occurred while deleting the ratingList: {e.Message}");
        }
    }

}