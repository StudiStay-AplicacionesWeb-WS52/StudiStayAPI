namespace StudiStayAPI.Rooms.Domain.Models;

/// <summary>
/// Entidad que representa la ubicación de los lugares
/// </summary>

public class Location
{

    public int Id { get; set; }

    public string Address { get; set; }
    
    public string Country { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }

}
