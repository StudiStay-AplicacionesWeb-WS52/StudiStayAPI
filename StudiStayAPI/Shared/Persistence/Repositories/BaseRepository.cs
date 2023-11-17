using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

/// <summary>
/// Repositorio Base para todos los demas repositorios
/// </summary>
public class BaseRepository
{
    protected readonly AppDbContext context;

    public BaseRepository(AppDbContext context)
    {
        this.context = context;
    }
}