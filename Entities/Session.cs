using System.ComponentModel.DataAnnotations;

namespace WikipediaExtractor.Entities;

public class Session
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [MaxLength(36)]
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddMinutes(5);
}

public record SessionDto(string Token, DateTime ExpiresAt);
