using WikipediaExtractor.Entities;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Data;
using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Services;

public class SearchService(InMemoryDbContext _context) : ISearchService
{
    public async Task<Response<SearchResult>> RunSearchAsync(string query, int userId)
    {
        // Run search against Wikipedia and extract data
        var searchResult = new SearchResult
        {
            SearchTerm = query,
            UserId = userId
        };

        // Save search data into the database
        _context.SearchResult.Add(searchResult);
        await _context.SaveChangesAsync();

        return Response<SearchResult>.SuccessResponse(searchResult, "", 200);
    }
}