using WikipediaExtractor.Entities;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Data;
using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Services;

public class SearchService(InMemoryDbContext _context) : ISearchService
{
    public async Task<Response<SearchResult>> RunSearchAsync(string query, int userId)
    {
        // Note: This is non-functional due to rate limits. Returning part-static mock.
        // WikipediaClient.DefaultRequestHeaders.UserAgent.ParseAdd(
        //     "WikipediaExtractor/1.3 (contact@example.com)"
        // );
        // var result = WikipediaClient.GetAsync(
        //     "/w/api.php?action=query&list=search&srsearch=ruby&format=json").Result;

        // Run search against Wikipedia and extract data
        var searchResult = new SearchResult
        {
            SearchTerm = query,
            UserId = userId,
            TotalResults = 5,
            SuggestedKeyword = "Wikipedia"
        };

        // Save search data into the database
        _context.SearchResult.Add(searchResult);
        await _context.SaveChangesAsync();

        return Response<SearchResult>.SuccessResponse(searchResult, "", 200);
    }

    private static readonly HttpClient WikipediaClient = new()
    {
        // PATH = /w/index.php?title=Special:Search&fulltext=1&search=ruby&ns0=1
        BaseAddress = new Uri("https://en.wikipedia.org")
    };
}