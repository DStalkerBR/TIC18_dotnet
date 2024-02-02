namespace MiddlewareUtils;

public class HeaderMiddleware
{
    private readonly RequestDelegate _next;

    public HeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add("X-Server-Header", new string[] { $"Hora: {DateTime.Now}, IP: {context.Connection.RemoteIpAddress}" });
            return Task.CompletedTask;
        });

        await _next(context);
    }
}
