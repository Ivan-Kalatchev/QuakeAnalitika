using Microsoft.AspNetCore.Diagnostics;

namespace QuakeAnalitika.ExceptionHandlers;

public class ArgumentExceptionHandler(ILogger<GenericExceptionHandler> logger) : IExceptionHandler
{

    private readonly ILogger<GenericExceptionHandler> _Logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ArgumentException argException) return false;
        _Logger.LogError(exception, $"An ArgumentException occurred with request aimed at {httpContext.Request.Path.Value ?? "N/A"} with method {httpContext.Request.Method ?? "N/A"}");
        httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //await httpContext.Response.WriteAsJsonAsync(new RilaExceptionData($"Bad argument \"{argException.ParamName}\". If this error persists please contact your system administrator immediately.", StatusCodes.Status500InternalServerError), cancellationToken: cancellationToken);
        return true;
    }

}
