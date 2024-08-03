using BlogApp.Application.Contracts.Articles;

namespace BlogApp.Application.Contracts.Tags;

public class TagUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}