using Microsoft.AspNetCore.Diagnostics;

namespace QuakeAnalitika.ExceptionHandlers;

public class GenericExceptionHandler(ILogger<GenericExceptionHandler> logger) : IExceptionHandler
{

    private readonly ILogger<GenericExceptionHandler> _Logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _Logger.LogError(exception, $"An error occurred with request aimed at {httpContext.Request.Path.Value ?? "N/A"} with method {httpContext.Request.Method ?? "N/A"}");
        //await httpContext.Response.WriteAsJsonAsync(new RilaExceptionData(exception.Message, StatusCodes.Status500InternalServerError), cancellationToken: cancellationToken);
        return true;
    }

}
