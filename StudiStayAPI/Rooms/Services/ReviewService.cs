using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }
    
    public async Task<ReviewApiResponse> SaveAsync(Review review)
    {
        try
        {
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewApiResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewApiResponse($"An error occurred when saving the review: {e.Message}");
        }
    }
    
    public async Task<ReviewApiResponse> DeleteAsync(int id)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(id);
        if (existingReview == null) return new ReviewApiResponse("Review not found.");
        
        try
        {
            _reviewRepository.Remove(existingReview);
            await _unitOfWork.CompleteAsync();
            return new ReviewApiResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewApiResponse($"An error occurred when deleting the review: {e.Message}");
        }
    }
    
    public async Task<IEnumerable<Review>> ListByPostIdAsync(int postId)
    {
        return await _reviewRepository.ListByPostIdAsync(postId);
    }
    
}