using Microsoft.EntityFrameworkCore;
using NewsFeedBackend.Data;
using NewsFeedBackend.Models;

namespace NewsFeedBackend.Services;

public class NewsService(NewsDbContext context)
{
    public IEnumerable<NewsItem> GetAll(
        bool? isHot,
        string? title, 
        string? author, 
        string? createdStart, 
        string? createdEnd,
        string? content)
    {
        var query = context.NewsItems.AsQueryable();

        if (isHot != null)
        {
            query = query.Where(newsItem => newsItem.IsHot == true);
        }

        if (title != null)
        {
            query = query.Where(newsItem => newsItem.Title.ToLower().Contains(title.ToLower()));
        }
        
        if (author!= null)
        {
            query = query.Where(newsItem => newsItem.Author.ToLower().Contains(author.ToLower()));
        }
        
        if (createdStart!= null)
        {
            query = query
                .Where(newsItem => newsItem.CreatedTimestamp >= DateTime.Parse(createdStart).ToUniversalTime());
        }
        
        if (createdEnd!= null)
        {
            query = query
                .Where(newsItem => newsItem.CreatedTimestamp <= DateTime.Parse(createdEnd).ToUniversalTime());
        }

        if (content != null)
        {
            query = query.Where(newsItem => newsItem.Content.ToLower().Contains(content.ToLower()));
        }

        return query.AsEnumerable().OrderByDescending(n => n.Id).ToList();
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
        item.IsHot = newsItem.IsHot;
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