using NewsFeedBackend.Data;
using NewsFeedBackend.Models;

namespace NewsFeedBackend.Services;

public class NewsService(NewsDbContext context)
{
    public IEnumerable<NewsItem> GetAll()
    {
        return context.NewsItems.OrderByDescending(n => n.Id).ToList();
    }

    public NewsItem? GetById(int id) {
        return context.NewsItems.Find(id);
    }

    public NewsItem Add(NewsItem newsItem)
    {
        var result = context.NewsItems.Add(newsItem);
        context.SaveChanges();
        return result.Entity;
    }

    public NewsItem? Update(NewsItem newsItem)
    {
        var item = context.NewsItems.Find(newsItem.Id);
        if (item == null) return null;
        
        item.Content = newsItem.Content;
        item.Title = newsItem.Title;
        item.Author = newsItem.Author;
        context.SaveChanges();

        return item;
    }

    public NewsItem? Remove(int id)
    {
        var newsItem = context.NewsItems.Find(id);
        if (newsItem == null) return null;
        
        context.NewsItems.Remove(newsItem);
        context.SaveChanges();
        return newsItem;
    }
}