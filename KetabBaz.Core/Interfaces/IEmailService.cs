﻿namespace KetabBaz.Core.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage message);
}
