using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

public class UniversityRepository : BaseRepository, IUniversityRepository
{
    public UniversityRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<University>> ListAsync()
    {
        return await context.Universities.ToListAsync();
    }

    public async Task AddAsync(University university)
    {
        await context.Universities.AddAsync(university);
    }

    public async Task<University> FindByIdAsync(int universityId)
    {
        return await context.Universities.FindAsync(universityId);
    }

    public async Task<University> FindByNameAsync(string name)
    {
        return await context.Universities.FirstOrDefaultAsync(u => u.Name == name);
    }

    public void Update(University university)
    {
        context.Universities.Update(university);
    }

    public void Remove(University university)
    {
        context.Universities.Remove(university);
    }
}