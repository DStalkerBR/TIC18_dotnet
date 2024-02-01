namespace CarBuilder.MinimalAPI;

public class ChassiMiddleware
{
    private readonly RequestDelegate _next;

    public ChassiMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var chassi = new string[] {"Fibra de Carbono", "Aco", "Aluminio"};
        var index = new Random().Next(chassi.Length);
        await context.Response.WriteAsync($"Chassi: {chassi[index]}\n");
        await _next(context);
    }

}
