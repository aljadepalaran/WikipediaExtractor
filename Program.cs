using WikipediaExtractor.Services;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddScoped<ISessionService, SessionService>()
    .AddScoped<IRegistrationService, RegistrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapRegistrationEndpoints();
app.MapSessionEndpoints();

app.Run();
