using WikipediaExtractor.Entities;
using WikipediaExtractor.Contracts;

namespace WikipediaExtractor.Interfaces;

public interface ISearchService
{
    Task<Response<SearchResult>> RunSearchAsync(string query, int userId);
}