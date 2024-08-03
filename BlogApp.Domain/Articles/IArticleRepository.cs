using BlogApp.Application.Contracts.Articles;

namespace BlogApp.Domain.Articles;

public interface IArticleRepository
{
    Task<Article?> GetByIdAsync(Guid id);
    Task<IEnumerable<Article>> GetAllAsync(int page, int pageSize, string sortBy, bool ascending);
    Task<Article> CreateAsync(Article? article);
    Task<Article> UpdateAsync(Article article);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByTitleAsync(string title);
    Task<IEnumerable<Article>> SearchAsync(ArticleSearchCriteria query);
    Task IncrementViewsAsync(Guid id);
    Task<IEnumerable<Article>> GetRecentlyPublishedAsync();
}