using StudiStayAPI.Rooms.Controllers;
using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

public class CalificationService : ICalificationService
{
    private readonly ICalificationRepository _calificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CalificationService(ICalificationRepository calificationRepository, IUnitOfWork unitOfWork)
    {
        _calificationRepository = calificationRepository;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<Calification>> ListAsync()
    {
        return await _calificationRepository.ListAsync();
    }
    
    public async Task<CalificationApiResponse> SaveAsync(Calification calification)
    {
        try
        {
            await _calificationRepository.AddAsync(calification);
            await _unitOfWork.CompleteAsync();
            return new CalificationApiResponse(calification);
        }
        catch (Exception e)
        {
            return new CalificationApiResponse($"An error occurred when saving the calification: {e.Message}");
        }
    }
    
    public async Task<CalificationApiResponse> DeleteAsync(int id)
    {
        var existingCalification = await _calificationRepository.FindByIdAsync(id);
        if (existingCalification == null) return new CalificationApiResponse("Calification not found.");
        
        try
        {
            _calificationRepository.Remove(existingCalification);
            await _unitOfWork.CompleteAsync();
            return new CalificationApiResponse(existingCalification);
        }
        catch (Exception e)
        {
            return new CalificationApiResponse($"An error occurred when deleting the calification: {e.Message}");
        }
    }
    
}