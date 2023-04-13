using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTest.Account.Application.Features.Accounts;

namespace ScheduleTest.Account.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHangfire(x => x.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));
        services.AddScoped<IAccountService, AccountService>();
        //services.AddHangfireServer();
        return services;
    }
}