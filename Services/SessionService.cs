using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Contracts;
using Microsoft.AspNetCore.Identity;

namespace WikipediaExtractor.Services;

public class SessionService : ISessionService
{
    public async Task LoginAsync(LoginRequest request)
    {
        // Fetch user
        // Validate password
        // TODO: Implement LoginAsync
    }

    public async Task LogoutAsync()
    {
        // TODO: Implement LogoutAsync
    }
}
