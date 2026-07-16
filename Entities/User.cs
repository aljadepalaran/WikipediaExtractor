using System.ComponentModel.DataAnnotations;

namespace WikipediaExtractor.Entities;

public class User
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;
}