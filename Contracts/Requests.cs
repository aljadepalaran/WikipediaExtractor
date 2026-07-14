namespace WikipediaExtractor.Contracts;

public class RegistrationRequest
{
    public string Username {get;set;} = string.Empty;
    public string FirstName { get;set; } = string.Empty;
    public string LastName { get;set; } = string.Empty;
    public string Password {get;set;} = string.Empty;
}

public class LoginRequest
{
    public string Username {get;set;} = string.Empty;

    public string Password {get;set;} = string.Empty;
}