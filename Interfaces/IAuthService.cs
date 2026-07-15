using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> AuthenticateRequestAsync(HttpContext context); 
}