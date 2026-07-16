using System.ComponentModel.DataAnnotations;

namespace WikipediaExtractor.Entities;

public class SearchResult
{
    public int Id { get; set; }

    public int UserId { get; set; }

    [MaxLength(50)]
    public string SearchTerm { get; set; } = string.Empty;

    public int? TotalResults { get; set; }

    [MaxLength(50)]
    public string? SuggestedKeyword { get; set; }
}