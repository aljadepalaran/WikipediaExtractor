using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;

namespace WikipediaExtractor.Services;

public class AuthService : IAuthService
{
    public async Task<AuthResponse> AuthenticateRequestAsync(HttpContext context)
    {
        var authToken = context.Request.Headers["Token"];
        // Session.FindByToken(authToken);
        // If the session exists, return with UserId
        // If the session does not exist, return AuthResponse.Authenticated = false
        if(authToken == "Token")
        {
            return new AuthResponse
            {
                UserId = 123,
                Authenticated = true
            };
        }
        else
        {
            return new AuthResponse
            {
                UserId = 0,
                Authenticated = false
            };
        }
    }
}