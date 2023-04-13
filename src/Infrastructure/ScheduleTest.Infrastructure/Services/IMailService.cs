using ScheduleTest.Infrastructure.Models;

namespace ScheduleTest.Infrastructure.Services;

public interface IMailService
{
    Task<bool> SendEmail(MailDto email);
}