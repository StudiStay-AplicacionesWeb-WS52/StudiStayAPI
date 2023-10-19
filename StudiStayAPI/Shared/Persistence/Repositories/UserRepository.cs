using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

/// <summary>
/// Repositorio para manejar las transacciones de la base de datos de los usuarios
/// </summary>
public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) {}

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }

    public void Remove(User user)
    {
        context.Users.Remove(user);
    }
}