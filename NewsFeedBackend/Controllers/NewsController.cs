using Microsoft.AspNetCore.Mvc;
using NewsFeedBackend.DTO;
using NewsFeedBackend.Models;
using NewsFeedBackend.Services;

namespace NewsFeedBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController(NewsService newsService) : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(newsService.GetAll());
        }
        
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            var newsItem = newsService.GetById(id);
            if (newsItem == null) return NotFound();
            
            return Ok(newsItem);
        }
        
        [HttpPut]
        public ActionResult Put([FromBody] NewsItemDto? newsItemDto)
        {
            if (newsItemDto == null)
            {
                return BadRequest("Invalid input. Pass the DTO item to create new news item.");
            }

            if (newsItemDto.Id != null)
            {
                var result = newsService.Update(new NewsItem()
                {
                    Id = newsItemDto.Id ?? 0,
                    Title = newsItemDto.Title,
                    Content = newsItemDto.Content,
                    Author = newsItemDto.Author
                });

                return Ok(result);
            }

            var newsItem = newsService.Add(new NewsItem
            {
                Title = newsItemDto.Title,
                Content = newsItemDto.Content,
                Author = newsItemDto.Author
            });

            return Ok(newsItem);
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(newsService.Remove(id));
        }
    }
}
