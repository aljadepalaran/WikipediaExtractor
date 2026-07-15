namespace WikipediaExtractor.Entities;

public class SearchResult
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SearchTerm { get; set; } = string.Empty;
    public int TotalResults { get; set; }
    public int ThumbnailCount { get; set; }
    public int TotalLinks { get; set; }
    public string Content { get; set; } = string.Empty;
}
