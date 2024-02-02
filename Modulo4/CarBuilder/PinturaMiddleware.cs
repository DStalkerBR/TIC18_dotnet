namespace CarBuilder.MinimalAPI;

public class PinturaMiddleware
{
    private readonly RequestDelegate _next;

    public PinturaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, LinhaMontagem linhaMontagem)
    {
        var pintura = new string[] { "Azul", "Preto", "Branco" };
        var index = new Random().Next(pintura.Length);
        linhaMontagem.Pintura = pintura[index];
        await _next(context);
    }

}
