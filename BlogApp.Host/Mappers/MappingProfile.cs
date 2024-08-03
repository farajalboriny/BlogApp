using AutoMapper;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Application.Contracts.Tags;
using BlogApp.Domain.Articles;
using BlogApp.Domain.Categories;
using BlogApp.Domain.Tags;

namespace BlogApp.Host.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Article, ArticleDto>();
        CreateMap<ArticleDto,Article>();
        CreateMap<Tag, TagDto>();
        CreateMap<TagDto, Tag>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}