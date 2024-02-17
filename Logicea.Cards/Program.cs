using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Logicea.Cards.Data;
using Logicea.Cards.Services;
using Logicea.Cards.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddFastEndpoints()
    .AddJWTBearerAuth(builder.Configuration["JwtSigningKey"]!)
    .AddAuthorization()
    .SwaggerDocument();

// Add services to the container.
builder.Services.AddDbContext<LogiceaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(c => c.Serializer.Options.PropertyNamingPolicy = null)
   .UseSwaggerGen();

app.Run();
