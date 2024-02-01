namespace CarBuilder.MinimalAPI;

public class InternoMiddleware
{
    private readonly RequestDelegate _next;

    public InternoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var interno = new string[] { "Couro", "Tecido", "Plastico" };
        var index = new Random().Next(interno.Length);
        await context.Response.WriteAsync($"Interno: {interno[index]}\n");
    }

}
