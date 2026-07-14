using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Interfaces;

public interface ISessionService
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> LogoutAsync();
}
