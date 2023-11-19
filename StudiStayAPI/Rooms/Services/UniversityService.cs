using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;
using StudiStayAPI.Security.Domain.Repositories;

namespace StudiStayAPI.Rooms.Services;

public class UniversityService : IUniversityService
{
    private readonly IUniversityRepository universityRepository;
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    
    //inyeccion de dependencias
    public UniversityService(IUniversityRepository universityRepository, ILocationRepository locationRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        this.universityRepository = universityRepository;
        this.userRepository = userRepository;
        this.locationRepository = locationRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<University>> ListAsync()
    {
        return await universityRepository.ListAsync();
    }
    
    public async Task<UniversityApiResponse> SaveAsync(University university)
    {
        //valida el nombre que no se repita
        var existingUWithName = await universityRepository.FindByNameAsync(university.Name);
        if (existingUWithName != null) return new UniversityApiResponse("University name already exists.");
        
        try
        {
            //guarda
            await universityRepository.AddAsync(university);
            //completa la transaccion
            await unitOfWork.CompleteAsync();
            //retorna el obj como response
            return new UniversityApiResponse(university);
        }
        catch (Exception e)
        {
            return new UniversityApiResponse($"An error occurred while saving the university: {e.Message}");
        }
    }

    public async Task<UniversityApiResponse> UpdateAsync(int universityId, University university)
    {
        //valida si existe
        var existingUniversity = await universityRepository.FindByIdAsync(universityId);
        if (existingUniversity == null) return new UniversityApiResponse("University not found.");
        
        //valida si el nombre ya existe y no es el mismo
        var existingUWithName = await universityRepository.FindByNameAsync(university.Name);
        if (existingUWithName != null && existingUWithName.Id != existingUniversity.Id) 
            return new UniversityApiResponse("University name already exists.");
        
        //modifica 
        existingUniversity.Name = university.Name ?? existingUniversity.Name;
        existingUniversity.LogoUrl = university.LogoUrl ?? existingUniversity.LogoUrl;
        existingUniversity.Initials = university.Initials ?? existingUniversity.Initials;

        try
        {
            universityRepository.Update(existingUniversity);
            await unitOfWork.CompleteAsync();
            return new UniversityApiResponse(existingUniversity);
        }
        catch (Exception e)
        {
            return new UniversityApiResponse($"An error occurred while updating the university: {e.Message}");
        }
    }

    public async Task<UniversityApiResponse> DeleteAsync(int universityId)
    {
        //valida si existe
        var existingUniversity = await universityRepository.FindByIdAsync(universityId);
        if (existingUniversity == null) return new UniversityApiResponse("University not found.");

        try
        {
            universityRepository.Remove(existingUniversity);
            await unitOfWork.CompleteAsync();
            return new UniversityApiResponse(existingUniversity);
        }
        catch (Exception e)
        {
            return new UniversityApiResponse($"An error occurred while deleting the university: {e.Message}");
        }
    }
}