using CarBuilder.MinimalAPI;
using MiddlewareUtils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<LinhaMontagem>();
var app = builder.Build();


app.UseMiddleware<ExceptionInterceptor>();
app.UseMiddleware<HeaderMiddleware>();
app.UseMiddleware<TimeMiddleware>();
app.UseMiddleware<ChassiMiddleware>();
app.UseMiddleware<MotorMiddleware>();
app.UseMiddleware<PortasMiddleware>();
app.UseMiddleware<PinturaMiddleware>();
app.UseMiddleware<InternoMiddleware>();

app.Run(
    async (context) =>
    {
        var linhaMontagem = context.RequestServices.GetRequiredService<LinhaMontagem>();
        await context.Response.WriteAsync(linhaMontagem.toString());    }
);

app.UseHttpsRedirection();

app.Run();
