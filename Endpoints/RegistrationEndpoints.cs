using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Endpoints;
public static class RegistrationEndpoints
{
    public static void MapRegistrationEndpoints(this WebApplication app)
    {
        app.MapPost("/register", HandleRegistrationAsync)
            .WithName("Register")
            .WithSummary("Register a user")
            .WithDescription("Returns a new user object")
            .Produces<Response<User>>();;
    }

    private static async Task<Response<User>> HandleRegistrationAsync(RegistrationRequest request, IRegistrationService registrationService)
    {
        var response = await registrationService.RegisterAsync(request);
        return response;
    }
}
