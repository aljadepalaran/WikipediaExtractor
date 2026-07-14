using Microsoft.EntityFrameworkCore;
using WikipediaExtractor.Entities;

namespace WikipediaExtractor.Data;

public class InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : DbContext(options)
{
    public DbSet<User> User {get;set;}
}