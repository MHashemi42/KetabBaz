using MailKit.Net.Smtp;
using MimeKit;

namespace KetabBaz.Infrastructure.Services;

public class MailKitEmailService : IEmailService
{
    private readonly EmailConfiguration _emailConfiguration;

    public MailKitEmailService(EmailConfiguration emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
    }

    public async Task SendEmailAsync(EmailMessage message)
    {
        MimeMessage mimeMessage = CreateEmailMessage(message);
        await SendAsync(mimeMessage);
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfiguration.Host,
                _emailConfiguration.Port, true);

            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.Email,
                _emailConfiguration.Password);

            await client.SendAsync(mailMessage);
        }
        catch
        {
            //log an error message or throw an exception, or both.
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }

    private MimeMessage CreateEmailMessage(EmailMessage message)
    {
        MimeMessage emailMessage = new()
        {
            Subject = message.Subject,
            Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content }
        };

        emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From,
            _emailConfiguration.Email));
        emailMessage.To.Add(new MailboxAddress(string.Empty, message.To));

        return emailMessage;
    }
}
