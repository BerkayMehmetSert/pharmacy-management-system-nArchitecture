using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly IHttpContextAccessor _contextAccessor;

    public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor contextAccessor)
    {
        _next = next;
        _contextAccessor = contextAccessor;
        _httpExceptionHandler = new();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            // await LogException(context, exception);
            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }

    // private Task LogException(HttpContext context, Exception exception)
    // {
    //     List<LogParameter> logParameters = new()
    //     {
    //         new LogParameter
    //         {
    //             Type = context.GetType().Name,
    //             Value = exception.ToString()
    //         }
    //     };
    //
    //     LogDetail logDetail = new()
    //     {
    //         MethodName = _next.Method.Name,
    //         Parameters = logParameters,
    //         User = _contextAccessor.HttpContext?.User.Identity?.Name ?? "?"
    //     };
    //
    //     _loggerService.Info(JsonConvert.SerializeObject(logDetail));
    //     return Task.CompletedTask;
    // }
}