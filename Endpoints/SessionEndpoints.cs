using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;

namespace WikipediaExtractor.Endpoints;

public static class SessionEndpoints
{
    public static void MapSessionEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (ISessionService sessionService) =>
        {
            return "login";
            // run session service (login)
        });

        app.MapPost("/logout", async (ISessionService sessionService) =>
        {
            return "logout";
            // run session service (logout)
        });
    }
}
