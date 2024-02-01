namespace CarBuilder.MinimalAPI;

public class MotorMiddleware
{
    private readonly RequestDelegate _next;

    public MotorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var motor = new string[] { "V8", "V6", "V4" };
        var index = new Random().Next(motor.Length);
        await context.Response.WriteAsync($"Motor: {motor[index]}\n");
        await _next(context);
    }
}
