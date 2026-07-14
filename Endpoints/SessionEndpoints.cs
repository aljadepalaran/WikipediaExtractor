using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;

namespace WikipediaExtractor.Endpoints;

public static class SessionEndpoints
{
    public static void MapSessionEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (LoginRequest request,ISessionService sessionService) =>
        {
            return await sessionService.LoginAsync(request);
        });

        app.MapPost("/logout", async (ISessionService sessionService) =>
        {
            return await sessionService.LogoutAsync();
        });
    }
}
