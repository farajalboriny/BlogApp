using System.Net;
using System.Net.Mail;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Application.Contracts.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BlogApp.Application.Notifications;

public class NotificationService : INotificationService
{
    private readonly SmtpSettings _smtpSettings;

    public NotificationService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task Notify(ArticleDto articleDto)
    {
        using (var message = new MailMessage())
        {
            message.From = new MailAddress(_smtpSettings.SmtpUser, "Article Published");
            message.To.Add(new MailAddress(_smtpSettings.Target));
            message.Subject = "Article Published";
            message.Body = $"Article Title:{articleDto.Title} Published";
            message.IsBodyHtml = false;

            using (var client = new SmtpClient(_smtpSettings.SmtpServer, _smtpSettings.SmtpPort))
            {
                client.Credentials = new NetworkCredential(_smtpSettings.SmtpUser, _smtpSettings.SmtpPass);
                client.EnableSsl = true;

                await client.SendMailAsync(message);
            }
        }
    }
}