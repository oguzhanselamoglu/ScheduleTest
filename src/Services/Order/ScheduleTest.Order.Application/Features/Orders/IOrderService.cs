using ScheduleTest.Order.Application.Models;

namespace ScheduleTest.Order.Application.Features.Orders;

public interface IOrderService
{
    Task<string> AddOrder(OrderDto order);
}