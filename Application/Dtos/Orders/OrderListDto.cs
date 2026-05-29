using Domain.Entities;

namespace Application.Dtos.Orders
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int ItemsCount { get; set; }
    }
}
