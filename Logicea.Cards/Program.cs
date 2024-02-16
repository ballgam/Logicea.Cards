using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Logicea.Cards.Services;
using Logicea.Cards.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddFastEndpoints()
    .AddJWTBearerAuth(builder.Configuration["JwtSigningKey"]!)
    .AddAuthorization()
    .SwaggerDocument();

// Add services to the container.
builder.Services.AddTransient<ICardService, CardService>();

var app = builder.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(c => c.Serializer.Options.PropertyNamingPolicy = null)
   .UseSwaggerGen();

app.Run();
