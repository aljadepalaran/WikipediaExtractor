using WikipediaExtractor.Contracts;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Interfaces;

public interface IRegistrationService
{
    Task<Response<User>> RegisterAsync(RegistrationRequest request);
}