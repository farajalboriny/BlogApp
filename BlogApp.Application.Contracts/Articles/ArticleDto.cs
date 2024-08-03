using BlogApp.Application.Contracts.Articles;
using BlogApp.Application.Contracts.Tags;

namespace BlogApp.Application.Contracts.Articles;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Views { get; set; }
    public string? Status { get; set; }

    public List<TagDto> Tags { get; set; }
    public List<CategoryDto> Categories { get; set; }
  
}