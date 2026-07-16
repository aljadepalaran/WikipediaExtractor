using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Contracts;
using WikipediaExtractor.Data;
using WikipediaExtractor.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WikipediaExtractor.Services;

public class SessionService(InMemoryDbContext context) : ISessionService
{
    public async Task<Response<SessionDto>> LoginAsync(LoginRequest request)
    {
        var user = await context.User.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user != null)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                Console.WriteLine("Invalid username or password.");
                return Response<SessionDto>.FailureResponse(new SessionDto(string.Empty, DateTime.MinValue), "Invalid credentials.", 401);
            }
            else if (result == PasswordVerificationResult.Success)
            {
                Console.WriteLine($"Password validation passed. UserId: {user.Id}, UserName: {user.Username}");
                var existingSession = await context.Session.FirstOrDefaultAsync(session => session.UserId == user.Id);
                if (existingSession != null)
                {
                    if (existingSession.ExpiresAt < DateTime.UtcNow)
                    {
                        Console.WriteLine("Session expired. Creating a new session.");
                        // Generate a new session if login is successful but the session is expired.
                        var session = new Session
                        {
                            UserId = user.Id,
                            Token = Guid.NewGuid().ToString(),
                        };
                        context.Session.Add(session);
                        await context.SaveChangesAsync();
                        return Response<SessionDto>.SuccessResponse(new SessionDto(session.Token, session.ExpiresAt), "Login Successful.", 200);
                    }
                    else
                    {
                        Console.WriteLine("Session already exists. Returning old session.");
                        // Return the existing session.
                        // TODO: Consider deleting the session and re-creating.
                        return Response<SessionDto>.SuccessResponse(
                            new SessionDto(existingSession.Token, existingSession.ExpiresAt), "Login Successful.", 200);
                    }
                }
                else
                {
                    Console.WriteLine("There is no existing session. Creating a new session.");
                    var session = new Session
                    {
                        UserId = user.Id,
                        Token = Guid.NewGuid().ToString(),
                    };
                    context.Session.Add(session);
                    await context.SaveChangesAsync();
                    return Response<SessionDto>.SuccessResponse(new SessionDto(session.Token, session.ExpiresAt), "Login Successful.", 200);
                }
                
            }
            else
            {
                return Response<SessionDto>.FailureResponse(new SessionDto(string.Empty, DateTime.MinValue), "Something went wrong.", 500);
            }
        }
        else
        {
            return Response<SessionDto>.FailureResponse(new SessionDto(string.Empty, DateTime.MinValue), "Invalid credentials.", 401);
        }
    }

    public async Task<Response<string>> LogoutAsync()
    {
        // TODO: Implement LogoutAsync
        return Response<string>.SuccessResponse("", "Logout successful", 200);
    }

    public async Task<Response<List<Session>>> GetAllSessionsAsync()
    {
        var sessions = await context.Session.ToListAsync();
        return Response<List<Session>>.SuccessResponse(sessions, "", 200);
    }
}
