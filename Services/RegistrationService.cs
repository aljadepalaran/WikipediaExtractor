using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Contracts;
using WikipediaExtractor.Entities;
using WikipediaExtractor.Data;

using Microsoft.AspNetCore.Identity;

namespace WikipediaExtractor.Services;

public class RegistrationService(InMemoryDbContext _context) : IRegistrationService
{
    public async Task<Response<User>> RegisterAsync(RegistrationRequest request)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);
        _context.User.Add(user);
        await _context.SaveChangesAsync();

        return Response<User>.SuccessResponse(user, "User registered successfully");
    }
    
}