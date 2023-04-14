using System.Linq.Expressions;
using Hangfire;
using ScheduleTest.Infrastructure.Enums;
using ScheduleTest.Infrastructure.Models;
using ScheduleTest.Infrastructure.Services;

namespace ScheduleTest.Infrastructure.Managers;

public  class JobManager: IJobManager
{
    private readonly IMailService _mailService;

    public JobManager(IMailService mailService)
    {
        _mailService = mailService;
    }

    public void Execute<T, G>(Expression<Func<T, G>> expression) where T:class
    {
        var serviceNamespace = typeof(T).FullName;
        
        
        string actionName = ((MethodCallExpression)expression.Body).Method.Name;
        var result = Expression.Invoke(expression);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression">Method Expression</param>
    /// <param name="jobType">Recurring,Enqueue,Delete</param>
    /// <param name="id">id parameter is required for Recurring job </param>
    /// <param name="cronExpression"></param>
    /// <exception cref="Exception"></exception>
    public void Create(Expression<Func<Task>> expression,JobType jobType,string id = "",string cronExpression="" ) 
    {
        if (jobType == JobType.Recurring && string.IsNullOrEmpty(id))
        {
            throw new Exception("id parameter couldn't be null or empty");
        }
        if (jobType == JobType.Recurring && string.IsNullOrEmpty(cronExpression))
        {
            throw new Exception("cronExpression parameter couldn't be null or empty");
        }
        if (jobType == JobType.Recurring && !string.IsNullOrEmpty(id))
        {
            RecurringJob.RemoveIfExists(id);
        }
        switch (jobType)
        {
            case JobType.Recurring:
                RecurringJob.AddOrUpdate(id,expression,cronExpression,TimeZoneInfo.Local);
                break;
            case JobType.Delayed:
                break;
            case JobType.Enqueue:
                BackgroundJob.Enqueue(expression);
                break;
            case JobType.Delete:
                RecurringJob.RemoveIfExists(id);
                break;
            default:
                BackgroundJob.Enqueue(expression);
                break;
                
        }
       // RecurringJob.AddOrUpdate("",() => Execute(expression),cronexpression,TimeZoneInfo.Local);
     
    }

    public void Enqueue(Expression<Func<Task>> expression)
    {
        BackgroundJob.Enqueue(expression);
    }
    
    public void SendMail(MailDto mail,JobType jobType,string id="",string cron="")
    {
        switch (jobType)
        {
            case JobType.Recurring:
                RecurringJob.AddOrUpdate(id,()=>_mailService.SendEmail(mail),cron,TimeZoneInfo.Local);
                break;
            case JobType.Delayed:
                break;
            case JobType.Enqueue:
                BackgroundJob.Enqueue(() => _mailService.SendEmail(mail));
                break;
            case JobType.Delete:
                RecurringJob.RemoveIfExists(id);
                break;
            default:
                BackgroundJob.Enqueue(() => _mailService.SendEmail(mail));
                break;
                
        }
    }
}