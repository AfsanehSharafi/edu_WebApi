using Application.Dtos.Common;

namespace Application.Dtos
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
