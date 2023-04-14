using ScheduleTest.Infrastructure.Enums;
using ScheduleTest.Infrastructure.Managers;
using ScheduleTest.Infrastructure.Models;
using ScheduleTest.Infrastructure.Services;
using ScheduleTest.Order.Application.Models;

namespace ScheduleTest.Order.Application.Features.Orders;

public class OrderService: IOrderService
{
    private readonly IJobManager _job;

    public OrderService(IJobManager job)
    {
        _job = job;
    }

    public async Task<string> AddOrder(OrderDto order)
    {
        _job.SendMail(new MailDto
        {
            Body = "Order",
            Subject = "Test",
            To = order.Email
        },JobType.Enqueue);
        

        return "";
    }
}