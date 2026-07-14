using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Contracts;
using WikipediaExtractor.Data;
using WikipediaExtractor.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WikipediaExtractor.Services;

public class SessionService(InMemoryDbContext _context) : ISessionService
{
    public async Task<Response<string>> LoginAsync(LoginRequest request)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null)
        {
            return Response<string>.FailureResponse("User not found", null, 404);
        }
        else
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Response<string>.FailureResponse("Invalid password", null, 401);
            } else
            {
                return Response<string>.SuccessResponse("Login successful", "Login successful", 200);
            }
        }
    }

    public async Task<Response<string>> LogoutAsync()
    {
        // TODO: Implement LogoutAsync
        return Response<string>.SuccessResponse("Logout successful", "Logout successful", 200);
    }
}
