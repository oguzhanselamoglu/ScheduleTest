using System.Linq.Expressions;
using Hangfire;
using ScheduleTest.Account.Application.Models;
using ScheduleTest.Infrastructure.Enums;
using ScheduleTest.Infrastructure.Managers;
using ScheduleTest.Infrastructure.Models;
using ScheduleTest.Infrastructure.Services;

namespace ScheduleTest.Account.Application.Features.Accounts;

public class AccountService: IAccountService
{
    private readonly IJobManager _job;
    private readonly IMailService _mailService;

    public AccountService(IJobManager job, IMailService mailService)
    {
        _job = job;
        _mailService = mailService;
    }

    public async Task<string> CreateAccount(AccountDto account)
    {
        _job.Create(()=> _mailService.SendEmail(new MailDto
        {
            Body = "Deneme",
            Subject = "Test",
            To = account.Email,
        }),JobType.Recurring);
        
        // _job.Create(()=> _mailService.SendEmail(new MailDto
        // {
        //     Body = "Deneme",
        //     Subject = "Test",
        //     To = account.Email,
        // }),JobType.Recurring,"test",Cron.Minutely());
        
    //    _job.Create<MailService, Task<bool>>(x => x.SendEmail(new MailDto()), "test-01", "* * * *");
        // _job.SendMail(new MailDto
        // {
        //     Body = "Deneme",
        //     Subject = "Test",
        //     To = account.Email,
        // },JobType.Enqueue);
        // _job.Enqueue(()=>_mailService.SendEmail(new MailDto
        // {
        //     Body = "Deneme",
        //     Subject = "Test",
        //     To = account.Email,
        // }));
        return "";
    }
}