using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;

namespace WikipediaExtractor.Endpoints;

public static class SearchEndpoints
{ 
    public static void MapSearchEndpoints(this WebApplication app)
    {
        app.MapGet("/search", async (string query, ISearchService searchService) => 
        {
            // TODO: Authenticate token with user and supply userId
            var userId = 1;
            var response = await searchService.RunSearchAsync(query, userId);
            return response;
        });
    }
}