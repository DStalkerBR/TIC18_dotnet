namespace CarBuilder.MinimalAPI;

public class InternoMiddleware
{
    private readonly RequestDelegate _next;

    public InternoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, LinhaMontagem linhaMontagem)
    {
        var interno = new string[] { "Couro", "Tecido", "Plastico" };
        var index = new Random().Next(interno.Length);
        linhaMontagem.Interno = interno[index];
        if (!context.Response.HasStarted)
            await _next(context);        
        }

}
