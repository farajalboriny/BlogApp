using BlogApp.Application.Contracts.Articles;

namespace BlogApp.Application.Contracts.Articles;

public class CategoryUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}