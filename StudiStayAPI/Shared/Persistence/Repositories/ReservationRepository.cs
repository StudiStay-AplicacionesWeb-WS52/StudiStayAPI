using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

public class ReservationRepository : BaseRepository, IReservationRepository
{
    public ReservationRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<Reservation>> ListByPostIdAsync(int postId)
    {
        return await context.Reservations
            .Where(p => p.PostId == postId)
            .Include(p => p.Post)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Reservation>> ListByUserIdAsync(int userId) 
    {
        return await context.Reservations
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<Reservation> FindByIdAsync(int reservationId) 
    {
        return await context.Reservations
            .Include(p => p.Post)
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == reservationId);
    }
    
    public async Task AddAsync(Reservation reservation)
    {
        await context.Reservations.AddAsync(reservation);
    }

    public async Task<bool> isAvailableAsync(int postId, DateTime startDate, DateTime endDate) 
    {
        return !await context.Reservations
            .Where(p => p.PostId == postId)
            .AnyAsync(r => (startDate >= r.CheckInDate && startDate < r.CheckOutDate) || (endDate > r.CheckInDate && endDate <= r.CheckOutDate));
    }
    
    public void Update(Reservation reservation)
    {
        context.Reservations.Update(reservation);
    }

    public void Remove(Reservation reservation)
    {
        context.Reservations.Remove(reservation);
    }
}