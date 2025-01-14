namespace NewsFeedBackend.DTO;

public class NewsItemDto
{
    public int? Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Author { get; set; }
    public bool IsHot { get; set; }
}