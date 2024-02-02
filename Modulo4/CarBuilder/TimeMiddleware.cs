using System.Diagnostics;

namespace MiddlewareUtils;

public class TimeMiddleware
{
    private readonly RequestDelegate _next;

    public TimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _next(context);
        stopwatch.Stop();
        var responseTime = stopwatch.ElapsedMilliseconds;
        await context.Response.WriteAsync($"Tempo de resposta: {responseTime} ms");
    }

}
