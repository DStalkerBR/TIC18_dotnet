namespace CarBuilder.MinimalAPI;

public class PortasMiddleware
{
    private readonly RequestDelegate _next;

    public PortasMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var portas = new string[] { "2 Portas", "4 Portas", "5 Portas" };
        var index = new Random().Next(portas.Length);
        await context.Response.WriteAsync($"Portas: {portas[index]}\n");
        await _next(context);
    }
}
