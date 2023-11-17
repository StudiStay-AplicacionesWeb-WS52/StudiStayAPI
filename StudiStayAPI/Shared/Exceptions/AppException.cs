using System.Globalization;
using System.Net;

namespace StudiStayAPI.Shared.Exceptions;

/// <summary>
/// Excepción personalizada para la aplicación
/// </summary>
public class AppException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public AppException(HttpStatusCode statusCode, string message = "") : base(message)
    {
        StatusCode = statusCode;
    }

    public AppException(HttpStatusCode statusCode, string message, params object[] args) 
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
        StatusCode = statusCode;
    }
}