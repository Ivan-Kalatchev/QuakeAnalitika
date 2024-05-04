using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace QuakeAnalitika.ExceptionHandlers;

public class ValidationExceptionHandler(ILogger<GenericExceptionHandler> logger) : IExceptionHandler
{

    private readonly ILogger<GenericExceptionHandler> _Logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException apiException) return false;
        _Logger.LogError(exception, $"A ValidationException occurred with request aimed at {httpContext.Request.Path.Value ?? "N/A"} with method {httpContext.Request.Method ?? "N/A"}");
        httpContext.Response.StatusCode = 400;
        //await httpContext.Response.WriteAsJsonAsync(new RilaValidationExceptionData(apiException.Errors), cancellationToken: cancellationToken);
        return true;
    }

}

