using BlogApp.Application.Articles;
using BlogApp.Application.Categories;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Application.Contracts.Notifications;
using BlogApp.Application.Contracts.Tags;
using BlogApp.Application.Notifications;
using BlogApp.Application.Tags;
using BlogApp.Domain.Articles;
using BlogApp.Domain.Categories;
using BlogApp.Domain.Tags;
using BlogApp.EntityFrameworkCore;
using BlogApp.EntityFrameworkCore.Articles;
using BlogApp.EntityFrameworkCore.Categories;
using BlogApp.EntityFrameworkCore.Tags;
using BlogApp.Host.Mappers;
using BlogApp.HttpApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Host;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.AddDbContext<BlogAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
        builder.Services.AddControllers();
        builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.Services.AddScoped<ITagAppService, TagAppService>();
        builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
        builder.Services.AddScoped<IArticleAppService, ArticleAppService>();
        builder.Services.AddScoped<TagManager>();
        builder.Services.AddScoped<CategoryManager>();
        builder.Services.AddScoped<ArticleManager>();
        builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogAppDbContext>();
            dbContext.Database.Migrate();
        }

        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}