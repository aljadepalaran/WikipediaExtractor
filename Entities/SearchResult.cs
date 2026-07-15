namespace WikipediaExtractor.Entities;

public class SearchResult
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SearchTerm { get; set; } = string.Empty;
    public int? TotalResults { get; set; }
    public string? SuggestedKeyword { get; set; }
}