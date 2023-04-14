using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ScheduleTest.Infrastructure.Models;

namespace ScheduleTest.Infrastructure.Services;

public class MailService: IMailService
{
    public EmailSettings _emailSettings { get; set; }

    public MailService(IOptions<EmailSettings> emailSettings)
    {
        
    }

    public async Task<bool> SendEmail(MailDto email)
    {
        return true;
    }
}