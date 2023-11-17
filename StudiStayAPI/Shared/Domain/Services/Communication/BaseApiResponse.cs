namespace StudiStayAPI.Shared.Domain.Services.Communication;

/// <summary>
/// Clase abstracta que representa una respuesta de la API
/// </summary>
/// <typeparam name="T">Tipo de dato que se va a retornar</typeparam>
public abstract class BaseApiResponse<T>
{
    protected BaseApiResponse(string message, T resource)
    {
        Message = message;
        Resource = resource;
    }
    
    protected BaseApiResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }
    
    protected BaseApiResponse(T resource)
    {
        Success = true;
        Message = string.Empty; 
        Resource = resource;
    }
    
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
}