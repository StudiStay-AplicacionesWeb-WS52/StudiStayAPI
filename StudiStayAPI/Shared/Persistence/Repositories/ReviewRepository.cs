using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

public class ReviewRepository : BaseRepository, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await context.Reviews
            .Include(p => p.Post)
            .Include(p => p.Calification)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Review>> ListByPostIdAsync(int postId)
    {
        return await context.Reviews
            .Where(p => p.PostId == postId)
            .Include(p => p.Post)
            .Include(p => p.Calification)
            .ToListAsync();
    }
    
    public async Task AddAsync(Review review)
    {
        await context.Reviews.AddAsync(review);
    }
    
    public async Task<Review> FindByIdAsync(int id)
    {
        return await context.Reviews
            .Include(p => p.Post)
            .Include(p => p.Calification)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    
    public void Remove(Review review)
    {
        context.Reviews.Remove(review);
    }
    
}