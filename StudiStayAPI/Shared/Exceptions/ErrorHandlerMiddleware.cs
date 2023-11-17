using System.Text.Json;
using StudiStayAPI.Shared.Exceptions;

namespace StudiStayAPI.Shared.Exceptions;

/// <summary>
/// Manejador de errores personalizado para la aplicación
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = StatusCodes.Status500InternalServerError; // Código por defecto
            var message = error.Message;

            if (error is AppException appException)
            {
                statusCode = (int)appException.StatusCode; // Usa el código de estado de AppException
                message = appException.Message;
            }

            response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}