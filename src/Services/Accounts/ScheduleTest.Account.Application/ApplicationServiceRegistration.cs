using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTest.Account.Application.Features.Accounts;
using ScheduleTest.Infrastructure.Managers;
using ScheduleTest.Infrastructure.Models;
using ScheduleTest.Infrastructure.Services;

namespace ScheduleTest.Account.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHangfire(x => x.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));
        services.AddScoped<IAccountService, AccountService>();
        services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        services.AddTransient<IMailService, MailService>();
        services.AddSingleton<IJobManager, JobManager>();
        
       services.AddHangfireServer();
        
        return services;
    }
}