using Microsoft.OpenApi.Models;
using TechMed.Application.Services;
using TechMed.Application.Services.Interfaces;
using TechMed.Infrastructure.Persistence;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Application.Auth;
using TechMed.Infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ITechMedContext, TechMedContext>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<IExameService, ExameService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<TechMedDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/* builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new() { Title = "Simple_Auth.WebAPI", Version = "v1" });
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] {}
        }
    });
});
 */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<SimpleAuthHandler>();

app.Run();