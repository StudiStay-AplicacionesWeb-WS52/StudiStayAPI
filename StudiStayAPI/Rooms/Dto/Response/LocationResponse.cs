using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Dto.Response;
using System.Collections.Generic;

namespace StudiStayAPI.Rooms.Dto.Response;

/// <summary>
/// Clase que se usa para mapear el response del API (lo que se devuelve al cliente en formato JSON)
/// </summary>

public class LocationResponse
{

    public int Id { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }

}
