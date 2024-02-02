using System.Text.Json;

namespace MiddlewareUtils;

public class ExceptionInterceptor
{
    private readonly RequestDelegate _next;

    public ExceptionInterceptor(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(new { message = ex.Message, stackTrace = ex.StackTrace});
            await context.Response.WriteAsync(json);                      
        }
    }

}
