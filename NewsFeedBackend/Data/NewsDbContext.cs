using Microsoft.EntityFrameworkCore;
using NewsFeedBackend.Models;

namespace NewsFeedBackend.Data;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<NewsItem> NewsItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewsItem>().HasKey(n => n.Id);
    }
}