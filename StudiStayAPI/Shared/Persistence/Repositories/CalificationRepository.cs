using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Controllers;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

public class CalificationRepository : BaseRepository, ICalificationRepository
{
    public CalificationRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Calification>> ListAsync()
    {
        return await context.Califications
            .ToListAsync();
    }
    
    
    public async Task AddAsync(Calification calification)
    {
        await context.Califications.AddAsync(calification);
    }
    
    public async Task<Calification> FindByIdAsync(int id)
    {
        return await context.Califications
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public void Remove(Calification calification)
    {
        context.Califications.Remove(calification);
    }
    
}