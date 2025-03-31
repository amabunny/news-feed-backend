namespace NewsFeedBackend.Models;

public class NewsItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Author { get; set; }

    public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
    
    public bool? IsHot { get; set; }
    
    public bool? HasLargeContent { get; set; }
}
