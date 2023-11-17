using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Shared.Persistence.Contexts;

namespace StudiStayAPI.Shared.Persistence.Repositories;

/// <summary>
/// Clase que implementa la interfaz IUnitOfWork para manejar las transacciones de la base de datos
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    
    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}