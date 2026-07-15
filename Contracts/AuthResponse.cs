namespace WikipediaExtractor.Contracts;

public struct AuthResponse
{
    public int UserId { get; set; }
    public bool Authenticated { get; set; }
}