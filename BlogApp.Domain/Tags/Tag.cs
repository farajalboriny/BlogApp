using System.ComponentModel.DataAnnotations;
using BlogApp.Domain.Articles;

namespace BlogApp.Domain.Tags;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}