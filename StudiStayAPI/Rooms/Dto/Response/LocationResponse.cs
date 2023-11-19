namespace StudiStayAPI.Rooms.Dto.Response;

/// <summary>
/// Clase que se usa para mapear el response del API (lo que se devuelve al cliente en formato JSON)
/// </summary>

public class Location
{

    public int Id { get; set; }

    public string Address { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }

}
