using BlogApp.Application.Contracts.Articles;

namespace BlogApp.Application.Contracts.Articles;

public interface IArticleAppService
{
    Task<ArticleDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ArticleDto>> GetAllAsync(GetArticleInput getArticleInput);
    Task<ArticleDto> CreateAsync(ArticleCreateDto article);
    Task<ArticleDto> UpdateAsync(ArticleUpdateDto article);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByTitleAsync(string title);
    Task<IEnumerable<ArticleDto>> SearchAsync(ArticleSearchCriteria query);
    Task IncrementViewsAsync(Guid id);
    Task<IEnumerable<ArticleDto>> GetRecentlyPublishedAsync();
}