using Application.Dtos.OrderItems;
using Domain.Entities;

namespace Application.Dtos.Orders
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty; // از طریق User Repository/Include گرفته می‌شود
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
