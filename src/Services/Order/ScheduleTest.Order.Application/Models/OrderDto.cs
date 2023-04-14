namespace ScheduleTest.Order.Application.Models;

public class OrderDto
{
    public string OrderId { get; set; }
    public string Product { get; set; }
    public string Email { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}