﻿namespace BlogApp.Application.Notifications;

public class SmtpSettings
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPass { get; set; }
    public string Target { get; set; }
}
