using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using WasteLess.Domain.Interfaces;

namespace WasteLess.Infrastructure.ExternalServices
{
    public class SmtpEmailSender(IConfiguration configuration) : IEmailSender
    {
        public async Task SendEmailAsync(List<string> to, string subject, string htmlBody, CancellationToken ct = default)
        {
            var smtpUser = configuration["emailVerification:SmtpUser"];
            var smtpPass = configuration["emailVerification:SmtpPass"];
            var adminEmail = configuration["emailVerification:AdminEmail"];

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(smtpUser));
            foreach (var recipient in to)
            {
                email.To.Add(MailboxAddress.Parse(recipient));
            }
            email.ReplyTo.Add(MailboxAddress.Parse(adminEmail));
            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = htmlBody
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient(); 

            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls, ct);
            await smtp.AuthenticateAsync(smtpUser, smtpPass, ct);
            await smtp.SendAsync(email, ct);
            await smtp.DisconnectAsync(true, ct);
        }
    }
}

