using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Interfaces;

public interface ISessionService
{
    Task LoginAsync(LoginRequest request);
    Task LogoutAsync();
}
