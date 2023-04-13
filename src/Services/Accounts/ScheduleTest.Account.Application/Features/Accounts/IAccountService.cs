using ScheduleTest.Account.Application.Models;

namespace ScheduleTest.Account.Application.Features.Accounts;

public interface IAccountService
{
    Task<string> CreateAccount(AccountDto account);
}