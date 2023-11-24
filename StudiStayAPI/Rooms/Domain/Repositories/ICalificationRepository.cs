using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Controllers;

public interface ICalificationRepository
{
    Task<IEnumerable<Calification>> ListAsync();
    
    Task AddAsync(Calification calification);
    
    Task<Calification> FindByIdAsync(int id);
    
    void Remove(Calification calification);
}