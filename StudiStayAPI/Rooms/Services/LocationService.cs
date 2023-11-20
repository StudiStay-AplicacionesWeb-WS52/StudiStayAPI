using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

/// <summary>
/// Clase que implementa la interfaz ILocationService
/// </summary>
public class LocationService : ILocationService
{
    public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.locationRepository = locationRepository
    }

    public async Task<IEnumerable<Location>> ListAsync()
    {
        return await locationRepository.ListAsync();
    }

    public async Task<LocationApiResponse> GetByIdAsync(int locationId)
    {
        var existingLocation = await locationRepository.FindByIdAsync(locationId);
        if (existingLocation == null) return new LocationApiResponse("Location not found.");
        return new LocationApiResponse(existingLocation);
    }

    public async Task<IEnumerable<Location>> ListByUserIdAsync(int userId)
    {
        return await locationRepository.FindByUserIdAsync(userId);
    }

    public async Task<LocationApiResponse> SaveAsync(Location location)
    {
        //valida la dirección que no se repita
        var existingLocationWithAddress = await locationRepository.FindByAddressAsync(Location.Address);
        if (existingLocationWithAddress != null) return new LocationApiResponse("Location  already exists.");
        
        try
        {
            //guarda el location
            await locationRepository.AddAsync(location);
            //completa la transaccion
            await unitOfWork.CompleteAsync();
            //retorna el location como response
            return new LocationApiResponse(location);
        }
        catch (Exception e)
        {
            return new LocationApiResponse($"An error occurred while saving the location: {e.Message}");
        }
    }

    public async Task<LocationApiResponse> UpdateAsync(int locationId, Location location)
    {
        //valida si existe el location
        var existingLocation = await locationRepository.FindByIdAsync(locationId);
        if (existingLocation == null) return new LocationApiResponse("Location not found.");
        
        //valida si la dirección ya existe y no es el mismo location
        var existingLocationWithAddress = await locationRepository.FindByAddressAsync(location.Address);
        if (existingLocationWithAddress != null && existingLocationWithAddress.Id != existingLocation.Id) 
            return new LocationApiResponse("Location address already exists.");
        
        //modifica el Location
        existingLocation.Address = location.Address ?? existingLocation.Address;
        existingLocation.Country = location.Country ?? existingLocation.Country;
        existingLocation.City = location.City ?? existingLocation.City;
        existingLocation.State = Location.State ?? existingLocation.State;
        existingLocation.ZipCode = Location.ZipCode ?? existingLocation.ZipCode;

        try
        {
            locationRepository.Update(existingLocation);
            await unitOfWork.CompleteAsync();
            return new LocationApiResponse(existingLocation);
        }
        catch (Exception e)
        {
            return new LocationApiResponse($"An error occurred while updating the location: {e.Message}");
        }
    }

    public async Task<LocationApiResponse> DeleteAsync(int locationId)
    {
        //valida si existe el location
        var existingLocation = await locationRepository.FindByIdAsync(locationId);
        if (existingLocation == null) return new LocationApiResponse("Location not found.");

        try
        {
            locationRepository.Remove(existingLocation);
            await unitOfWork.CompleteAsync();
            return new LocationApiResponse(existingLocation);
        }
        catch (Exception e)
        {
            return new LocationApiResponse($"An error occurred while deleting the location: {e.Message}");
        }
    }

}