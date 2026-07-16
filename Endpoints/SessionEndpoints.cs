using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Endpoints;

public static class SessionEndpoints
{
    public static void MapSessionEndpoints(this WebApplication app)
    {
        app.MapPost("/login", HandleLogin)
            .WithName("Login")
            .WithSummary("Login with username and password")
            .WithDescription("Returns a new session with token")
            .Produces<Response<SessionDto>>();

        app.MapPost("/logout", HandleLogout)
            .WithName("Logout")
            .WithSummary("Logout the user")
            .WithDescription("Returns a string with status")
            .Produces<Response<SessionDto>>();

        app.MapGet("/sessions", HandleGetAllSessions)
            .WithName("GetAllSessions")
            .WithSummary("Gets all of the sessions in the database")
            .WithDescription("Returns a list of all sessions")
            .Produces<Response<SessionDto>>();
    }

    private static async Task<Response<SessionDto>> HandleLogin(LoginRequest request, ISessionService sessionService)
    {
        return await sessionService.LoginAsync(request);
    }

    private static async Task<Response<string>> HandleLogout(ISessionService sessionService)
    {
        return await sessionService.LogoutAsync();
    }

    private static async Task<Response<List<Session>>> HandleGetAllSessions(ISessionService sessionService)
    {
        return await sessionService.GetAllSessionsAsync();
    }
}
