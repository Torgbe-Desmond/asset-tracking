using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteLess.Domain.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> to, string subject, string htmlBody, CancellationToken ct = default);
        // or more domain-specific: SendWelcomeEmailAsync(User user), SendPasswordResetAsync(...)
    }
}
