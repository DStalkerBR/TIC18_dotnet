namespace CarBuilder.MinimalAPI;

public class MotorMiddleware
{
    private readonly RequestDelegate _next;

    public MotorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, LinhaMontagem linhaMontagem)
    {
        var motor = new string[] { "V8", "V6", "V4" };
        var index = new Random().Next(motor.Length);
        linhaMontagem.Motor = motor[index];
        throw new Exception("Erro ao montar o motor");
        await _next(context);
    }
}
