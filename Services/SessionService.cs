using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Contracts;
using WikipediaExtractor.Data;
using WikipediaExtractor.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WikipediaExtractor.Services;

public class SessionService(InMemoryDbContext _context) : ISessionService
{
    public async Task<Response<SessionDto>> LoginAsync(LoginRequest request)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user != null)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Response<SessionDto>.FailureResponse(new SessionDto(string.Empty, DateTime.MinValue), "Invalid password", 401);
            } else
            {
                // TODO: Be more specific with conditions to reach this
                var session = new Session
                {
                    UserId = user.Id,
                    Token = Guid.NewGuid().ToString(),
                };
                _context.Session.Add(session);
                await _context.SaveChangesAsync();
                return Response<SessionDto>.SuccessResponse(new SessionDto(session.Token, session.ExpiresAt), "Login Successful", 200);
            }
        }
        else
        {
            return Response<SessionDto>.FailureResponse(new SessionDto(string.Empty, DateTime.MinValue), "User not found", 404);
        }
    }

    public async Task<Response<string>> LogoutAsync()
    {
        // TODO: Implement LogoutAsync
        return Response<string>.SuccessResponse(null, "Logout successful", 200);
    }
}
