using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTest.Infrastructure.Managers;
using ScheduleTest.Infrastructure.Models;
using ScheduleTest.Infrastructure.Services;
using ScheduleTest.Order.Application.Features.Orders;

namespace ScheduleTest.Order.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHangfire(x => x.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));
        services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        services.AddTransient<IMailService, MailService>();
        services.AddSingleton<IJobManager, JobManager>();
        services.AddScoped<IOrderService, OrderService>();
        
       services.AddHangfireServer();
        
        return services;
    }
}