using Domain.Common;

namespace Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }

        // این محصول میتونه در چندین آیتم سفارش باشه
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
