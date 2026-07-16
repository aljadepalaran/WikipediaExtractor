using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Data;
using Microsoft.EntityFrameworkCore;

namespace WikipediaExtractor.Services;

public class AuthService(InMemoryDbContext dbContext) : IAuthService
{
    public async Task<AuthResponse> AuthenticateRequestAsync(HttpContext context)
    {
        var authToken = context.Request.Headers["Token"];
        var session = await dbContext.Session.FirstOrDefaultAsync(session => session.Token == authToken);

        if (session == null)
        {
            return new AuthResponse
            {
                UserId = 0,
                Authenticated = false
            };
        }
        else
        {
            return new AuthResponse
            {
                UserId = session.UserId,
                Authenticated = true
            };
        }
        
    }
}