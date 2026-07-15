using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Endpoints;

public static class SearchEndpoints
{ 
    public static void MapSearchEndpoints(this WebApplication app)
    {
        app.MapGet("/search", async (HttpContext context, string query,ISearchService searchService, IAuthService authService) => 
        {
            var authResponse = await authService.AuthenticateRequestAsync(context);

            if (!authResponse.Authenticated)
            {
                return Response<SearchResult>.FailureResponse(new SearchResult(), "", 401);
            }

            var userId = authResponse.UserId;
            var response = await searchService.RunSearchAsync(query, userId);
            return response;
        });
    }
}