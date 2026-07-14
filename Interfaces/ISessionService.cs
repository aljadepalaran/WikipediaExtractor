using WikipediaExtractor.Contracts;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Interfaces;

public interface ISessionService
{
    Task<Response<SessionDto>> LoginAsync(LoginRequest request);
    Task<Response<string>> LogoutAsync();
    Task<Response<List<Session>>> GetAllSessionsAsync();
}
