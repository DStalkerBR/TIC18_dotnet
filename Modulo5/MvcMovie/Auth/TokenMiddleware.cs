namespace MvcMovie.Auth;
public class TokenMiddleware
{
    private readonly RequestDelegate _next;
    public TokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Cookies["Authentication"];

        if (token != null)
        {
            context.Request.Headers.Add("Authorization", "Bearer " + token);
        }
        await _next(context);
    }
}
