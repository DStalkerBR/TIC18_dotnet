using CarBuilder.MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(
    async (context, next) =>
    {
        await context.Response.WriteAsync("Montagem do Carro: \n\n");
        await next();
    }
);

app.UseMiddleware<ChassiMiddleware>();
app.UseMiddleware<MotorMiddleware>();
app.UseMiddleware<PortasMiddleware>();
app.UseMiddleware<PinturaMiddleware>();
app.UseMiddleware<InternoMiddleware>();

app.UseHttpsRedirection();

app.Run();
