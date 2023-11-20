using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request;

/// <summary>
/// Esta clase se usa para mapear el request body a un objeto C# (la entidad Post, accion de actualizar)
/// </summary>
public class UpdatePostRequest
{

    [Required] 
    public float Score { get; set; }
    
    public string Comment { get; set; }

    
}