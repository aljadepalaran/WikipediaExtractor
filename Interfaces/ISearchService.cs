using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Interfaces;

public interface ISearchService
{
    Task<SearchResult> RunSearchAsync(string query, int userId);
}