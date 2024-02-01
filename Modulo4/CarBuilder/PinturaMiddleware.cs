namespace CarBuilder.MinimalAPI;

public class PinturaMiddleware
{
    private readonly RequestDelegate _next;

    public PinturaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var pintura = new string[] { "Azul", "Preto", "Branco" };
        var index = new Random().Next(pintura.Length);
        await context.Response.WriteAsync($"Pintura: {pintura[index]}\n");
        await _next(context);
    }

}
