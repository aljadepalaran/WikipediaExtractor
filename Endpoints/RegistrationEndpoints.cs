using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;

namespace WikipediaExtractor.Endpoints;
public static class RegistrationEndpoints
{
    public static void MapRegistrationEndpoints(this WebApplication app)
    {
        app.MapPost("/register", async (RegistrationRequest request, IRegistrationService registrationService) =>
        {
            var response = await registrationService.RegisterAsync(request);
            return response;
        });
    }
}
