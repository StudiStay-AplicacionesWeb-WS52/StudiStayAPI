using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las transacciones de la base de datos de los posts
/// </summary>
public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await context.Posts
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Post post)
    {
        await context.Posts.AddAsync(post);
    }

    public async Task<Post> FindByIdAsync(int postId)
    {
        return await context.Posts
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == postId);
    }

    public async Task<Post> FindByTitleAsync(string title)
    {
        return await context.Posts
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Post>> FindByUserIdAsync(int userId)
    {
        return await context.Posts
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Post post)
    {
        context.Posts.Update(post);
    }

    public void Remove(Post post)
    {
        context.Posts.Remove(post);
    }
}