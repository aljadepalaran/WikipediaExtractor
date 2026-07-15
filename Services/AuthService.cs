using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;

namespace WikipediaExtractor.Services;

public class AuthService : IAuthService
{
    public async Task<AuthResponse> AuthenticateRequestAsync(HttpContext context)
    {
        var authToken = context.Request.Headers["Token"];
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