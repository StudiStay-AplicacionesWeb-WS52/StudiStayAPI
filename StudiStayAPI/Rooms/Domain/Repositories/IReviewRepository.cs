using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> ListAsync();
    
    Task<IEnumerable<Review>> ListByPostIdAsync(int postId);

    Task AddAsync(Review review);
    
    Task<Review> FindByIdAsync(int id);
    
    void Remove(Review review);
}