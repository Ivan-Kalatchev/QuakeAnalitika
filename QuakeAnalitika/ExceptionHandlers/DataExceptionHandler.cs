using Microsoft.AspNetCore.Diagnostics;
using System.Data;

namespace QuakeAnalitika.ExceptionHandlers;

public class DataExceptionHandler(ILogger<GenericExceptionHandler> logger) : IExceptionHandler
{

    private readonly ILogger<GenericExceptionHandler> _Logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not DataException dataException) return false;
        _Logger.LogError(exception, $"An DataException occurred with request aimed at {httpContext.Request.Path.Value ?? "N/A"} with method {httpContext.Request.Method ?? "N/A"}");
        httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        //await httpContext.Response.WriteAsJsonAsync(new RilaExceptionData("Could not report to inner DB. If this error persists please contact your system administrator immediately.", StatusCodes.Status500InternalServerError), cancellationToken: cancellationToken);
        return true;
    }

}
