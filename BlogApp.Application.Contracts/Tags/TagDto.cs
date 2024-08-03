using BlogApp.Application.Contracts.Articles;

namespace BlogApp.Application.Contracts.Tags;

public class TagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}