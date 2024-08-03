using BlogApp.Application.Contracts.Articles;
using BlogApp.Domain.Articles;
using BlogApp.Domain.Categories;
using BlogApp.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.EntityFrameworkCore.Articles;

public class ArticleRepository(BlogAppDbContext context) : IArticleRepository
{
    public async Task<Article?> GetByIdAsync(Guid id)
    {
        await IncrementViewsAsync(id);
        return await context.Articles
            .Include(a => a.Tags)
            .Include(a => a.Categories)
            .FirstOrDefaultAsync(a => a.Id.Equals(id));
    }

    public async Task<IEnumerable<Article>> GetAllAsync(int page, int pageSize, string sortBy, bool ascending)
    {
        IQueryable<Article> query = context.Articles
            .Include(a => a.Tags)
            .Include(a => a.Categories);

        query = sortBy.ToLower() switch
        {
            "title" => ascending ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title),
            "publicationdate" => ascending
                ? query.OrderBy(a => a.PublicationDate)
                : query.OrderByDescending(a => a.PublicationDate),
            "views" => ascending ? query.OrderBy(a => a.Views) : query.OrderByDescending(a => a.Views),
            _ => query.OrderByDescending(a => a.PublicationDate),
        };

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<Article> CreateAsync(Article? article)
    {
        context.Articles.Add(article);
        await context.SaveChangesAsync();
        return article;
    }

    public async Task<Article> UpdateAsync(Article article)
    {
        context.Update(article);

        await context.SaveChangesAsync();
        return article;
    }


    public async Task DeleteAsync(Guid id)
    {
        await context.Articles.Where(s => s.Id == id).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByTitleAsync(string title)
    {
        return await context.Articles.AnyAsync(a => a.Title != null && a.Title.Equals(title));
    }

    public async Task<IEnumerable<Article>> SearchAsync(ArticleSearchCriteria criteria)
    {
        return await context.Articles
            .Where(a =>
                (string.IsNullOrWhiteSpace(criteria.Title) || a.Title.Contains(criteria.Title)) &&
                (string.IsNullOrWhiteSpace(criteria.Author) || a.Author.Contains(criteria.Author)) &&
                (string.IsNullOrWhiteSpace(criteria.Category) || a.Categories
                    .Any(c => c.Name.Contains(criteria.Category))) &&
                (string.IsNullOrWhiteSpace(criteria.Tag) || a.Tags
                    .Any(t => t.Name.Contains(criteria.Tag)))
            ).ToListAsync();
    }

    public async Task IncrementViewsAsync(Guid id)
    {
        await context.Articles.Where(b => b.Id.Equals(id))
            .ExecuteUpdateAsync(setters => setters.SetProperty(b => b.Views, b => b.Views + 1));
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Article>> GetRecentlyPublishedAsync()
    {
        var articles = await context.Articles
            .FromSqlRaw("EXEC GetRecentPublishedArticles")
            .AsNoTracking()
            .ToListAsync();
        var articleIds = articles.Select(a => a.Id).ToList();
        var articlesWithRelations = await context.Articles
            .Where(a => articleIds.Contains(a.Id))
            .Include(a => a.Tags)
            .Include(a => a.Categories)
            .AsNoTracking()
            .ToListAsync();
        return articlesWithRelations;
    }

    public async Task<IEnumerable<Tag?>> GetAllTagsAsync()
    {
        return await context.Tags.ToListAsync();
    }

    public async Task<IEnumerable<Category?>> GetAllCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }
}