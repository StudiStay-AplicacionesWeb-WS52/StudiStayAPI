namespace StudiStayAPI.Rooms.Domain.Repositories;

/// <summary>
/// Para manejar las transacciones de la base de datos
/// </summary>
public interface IUnitOfWork
{
    Task CompleteAsync();
}