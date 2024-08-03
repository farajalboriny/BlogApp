namespace BlogApp.Application.Contracts.Articles;

public class ArticleSearchCriteria
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Category { get; set; }
    public string? Tag { get; set; }
}