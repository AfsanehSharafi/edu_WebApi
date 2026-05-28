using Domain.Common;

namespace Domain.Entities
{
    public class OrderItems: BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // قیمت لحظه ای خرید

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
