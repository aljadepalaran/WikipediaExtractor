using Microsoft.EntityFrameworkCore;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Data;

public class InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Session> Session { get; set; }
    public DbSet<SearchResult> SearchResult { get; set; }
}