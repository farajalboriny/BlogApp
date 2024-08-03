using System.Collections;
using AutoMapper;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Domain.Articles;

namespace BlogApp.Application.Articles;

public class ArticleAppService(IMapper mapper, IArticleRepository articleRepository, ArticleManager articleManager)
    : IArticleAppService
{
    public async Task<ArticleDto?> GetByIdAsync(Guid id)
    {
        return mapper.Map<ArticleDto>(await articleRepository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<ArticleDto>> GetAllAsync(GetArticleInput getArticleInput)
    {
        return mapper.Map<IEnumerable<ArticleDto>>(await articleRepository.GetAllAsync(getArticleInput.Page,
            getArticleInput.PageSize,
            getArticleInput.SortBy, getArticleInput.Ascending));
    }

    public async Task<ArticleDto> CreateAsync(ArticleCreateDto article)
    {
        return await articleManager.CreateAsync(article);
    }

    public async Task<ArticleDto> UpdateAsync(ArticleUpdateDto article)
    {
        return await articleManager.UpdateAsync(article);
    }

    public Task DeleteAsync(Guid id)
    {
        return articleRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsByTitleAsync(string title)
    {
        return await articleRepository.ExistsByTitleAsync(title);
    }

    public async Task<IEnumerable<ArticleDto>> SearchAsync(ArticleSearchCriteria query)
    {
        return mapper.Map<IEnumerable<ArticleDto>>(await articleRepository.SearchAsync(query));
    }

    public async Task IncrementViewsAsync(Guid id)
    {
        await articleRepository.IncrementViewsAsync(id);
    }

    public async Task<IEnumerable<ArticleDto>> GetRecentlyPublishedAsync()
    {
        return mapper.Map<IEnumerable<ArticleDto>>(await articleRepository.GetRecentlyPublishedAsync());
    }
}