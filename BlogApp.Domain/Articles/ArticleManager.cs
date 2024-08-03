using AutoMapper;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Application.Contracts.Notifications;
using BlogApp.Domain.Categories;
using BlogApp.Domain.Tags;

namespace BlogApp.Domain.Articles;

public class ArticleManager(
    IArticleRepository articleRepository,
    ITagRepository tagRepository,
    ICategoryRepository categoryRepository,
    IMapper mapper,
    INotificationService notificationService)
{
    public async Task<ArticleDto> CreateAsync(ArticleCreateDto articleCreateDto)
    {
        var tags = (await tagRepository.GetQueryable()).Where(tag => articleCreateDto.TagIds.Contains(tag.Id)).ToList();
        var categories = (await categoryRepository.GetQueryable())
            .Where(category => articleCreateDto.CategoryIds.Contains(category.Id)).ToList();
        var article = new Article
        {
            Id = Guid.NewGuid(),
            Content = articleCreateDto.Content,
            Author = articleCreateDto.Author,
            Title = articleCreateDto.Title,
            PublicationDate = DateTime.Now,
            Status = articleCreateDto.Status,
            Tags = tags,
            Categories = categories
        };
        var articleDto = mapper.Map<ArticleDto>(await articleRepository.CreateAsync(article));
        //should be enum
        if (articleDto.Status.Equals("Published"))
        {
            _ = notificationService.Notify(articleDto);
        }

        return articleDto;
    }

    public async Task<ArticleDto> UpdateAsync(ArticleUpdateDto articleUpdateDto)
    {
        var tags = (await tagRepository.GetQueryable()).Where(tag => articleUpdateDto.TagIds.Contains(tag.Id)).ToList();
        var categories = (await categoryRepository.GetQueryable())
            .Where(category => articleUpdateDto.CategoryIds.Contains(category.Id)).ToList();
        var article = new Article
        {
            Id = articleUpdateDto.Id,
            Content = articleUpdateDto.Content,
            Author = articleUpdateDto.Author,
            Title = articleUpdateDto.Title,
            PublicationDate = DateTime.Now,
            Status = articleUpdateDto.Status,
            Tags = tags,
            Categories = categories
        };
        var articleDto = mapper.Map<ArticleDto>(await articleRepository.UpdateAsync(article));
        //should be enum
        if (articleDto.Status.Equals("Published"))
        {
            _ = notificationService.Notify(articleDto);
        }

        return articleDto;
    }
}