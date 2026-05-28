using Domain.Common;

namespace Domain.Entities
{

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }


    public class Order: BaseEntity
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    }
}
