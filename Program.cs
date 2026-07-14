using WikipediaExtractor.Services;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Endpoints;
using WikipediaExtractor.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    // Load services through dependency injection
    .AddScoped<ISessionService, SessionService>()
    .AddScoped<IRegistrationService, RegistrationService>()
    .AddDbContext<InMemoryDbContext>(options => 
        options.UseInMemoryDatabase(
            builder.Configuration.GetConnectionString("InMemoryDatabase")!
        ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapRegistrationEndpoints();
app.MapSessionEndpoints();

app.Run();
