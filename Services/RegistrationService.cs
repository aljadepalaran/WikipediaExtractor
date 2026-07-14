using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Contracts;
using WikipediaExtractor.Entities;
using Microsoft.AspNetCore.Identity;

namespace WikipediaExtractor.Services;

public class RegistrationService : IRegistrationService
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
        return Response<User>.SuccessResponse(user, "User registered successfully");
    }
    
}