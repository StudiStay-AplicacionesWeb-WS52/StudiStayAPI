using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Security.Domain.Models;
using StudiStayAPI.Security.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;
using StudiStayAPI.Shared.Persistence.Repositories;

namespace StudiStayAPI.Security.Persistence.Repositories;

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

    public async Task<User> FindByEmailAsync(string email)
    {
        return await context.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return context.Users.Any(user => user.Email == email);
    }

    public User FindById(int id)
    {
        return context.Users.Find(id);
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