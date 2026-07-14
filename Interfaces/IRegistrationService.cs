using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Interfaces;

public interface IRegistrationService
{
    Task RegisterAsync(RegistrationRequest request);
}