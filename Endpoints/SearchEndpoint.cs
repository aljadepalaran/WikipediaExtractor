using WikipediaExtractor.Contracts;
using WikipediaExtractor.Interfaces;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Endpoints;

public static class SearchEndpoints
{ 
    public static void MapSearchEndpoints(this WebApplication app)
    {
        app.MapGet("/search", async (HttpContext context, string query,ISearchService searchService) => 
        {
            var authResponse = AuthenticateRequest(context);

            if (!authResponse.Authenticated)
            {
                return Response<SearchResult>.FailureResponse(new SearchResult(), "", 401);
            }

            var userId = authResponse.UserId;
            var response = await searchService.RunSearchAsync(query, userId);
            return response;
        });
    }
    public static AuthenticationResponse AuthenticateRequest(HttpContext context)
    {
        var authToken = context.Request.Headers["Token"];
        if(authToken == "Token")
        {
            return new AuthenticationResponse
            {
                UserId = 123,
                Authenticated = true
            };
        }
        else
        {
            return new AuthenticationResponse
            {
                UserId = 123,
                Authenticated = false
            };
        }
    }

    public struct AuthenticationResponse
    {
        public int UserId { get; set; }
        public bool Authenticated { get; set; }
    }
}