using System.ComponentModel.DataAnnotations;
using BlogApp.Domain.Categories;
using BlogApp.Domain.Tags;

namespace BlogApp.Domain.Articles;

public class Article
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Views { get; set; }
    public string? Status { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Category> Categories { get; set; }
}