using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Interfaces;

public interface ISearchService
{
    static abstract Task<SearchResult> RunSearchAsync(string query, int userId);
}