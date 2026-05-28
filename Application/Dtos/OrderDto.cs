using Application.Dtos.Common;
using Domain.Entities;

namespace Application.Dtos
{
    public class OrderDto:BaseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
