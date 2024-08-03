using BlogApp.Application.Contracts.Articles;

namespace BlogApp.Application.Contracts.Notifications;

public interface INotificationService
{
    public Task Notify(ArticleDto articleDto);
}