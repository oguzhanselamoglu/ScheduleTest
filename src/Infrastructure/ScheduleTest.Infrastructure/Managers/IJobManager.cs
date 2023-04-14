using System.Linq.Expressions;
using ScheduleTest.Infrastructure.Enums;
using ScheduleTest.Infrastructure.Models;

namespace ScheduleTest.Infrastructure.Managers;

public interface IJobManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression">Method Expression</param>
    /// <param name="jobType">Recurring,Enqueue,Delete</param>
    /// <param name="id">id parameter is required for Recurring job </param>
    /// <param name="cronExpression"></param>
    /// <exception cref="Exception"></exception>
    void Create(Expression<Func<Task>> expression, JobType jobType, string id="", string cronExpression ="" );

    void SendMail(MailDto mail, JobType jobType,string id="",string cron="");

    void Enqueue(Expression<Func<Task>> expression);
}