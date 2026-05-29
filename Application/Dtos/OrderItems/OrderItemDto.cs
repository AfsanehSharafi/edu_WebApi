using Application.Dtos.Common;

namespace Application.Dtos.OrderItems
{
    public class OrderItemDto:BaseDto
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // قیمت لحظه ای خرید
        public decimal LineTotal => Quantity * Price;
    }
}
