using WikipediaExtractor.Entities;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Data;

namespace WikipediaExtractor.Services;

public class SearchService(InMemoryDbContext _context) : ISearchService
{
    public async Task<SearchResult> RunSearchAsync(string query, int userId)
    {
        var searchResult = new SearchResult
        {
            SearchTerm = query
        };

        _context.SearchResult.Add(searchResult);
        await _context.SaveChangesAsync();

        return searchResult;
    }
}