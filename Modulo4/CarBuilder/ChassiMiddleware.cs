namespace CarBuilder.MinimalAPI;

public class ChassiMiddleware
{
    private readonly RequestDelegate _next;

    public ChassiMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, LinhaMontagem linhaMontagem)
    {
        var chassi = new string[] {"Fibra de Carbono", "Aco", "Aluminio"};
        var index = new Random().Next(chassi.Length);
        linhaMontagem.Chassi = chassi[index];
        await _next(context);
    }

}
