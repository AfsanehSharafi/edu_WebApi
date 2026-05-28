using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrderItemsRepository : GenericRepository<OrderItems>, IOrderItemsRepository
    {
        private readonly DataBaseContext _context;
        public OrderItemsRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsInOrderAsync(int orderId, int productId)
        {
            return await _context.OrderItems
                .AsNoTracking()
                .AnyAsync(oi => oi.OrderId == orderId & oi.ProductId == productId);
        }

        public async Task<IReadOnlyList<OrderItems>> GetItemsByOrderIdAsync(int orderId)
        {
            var orderItems = await _context.OrderItems
                .AsNoTracking()
                .Where(oi => oi.OrderId == orderId)
                .Include(oi=> oi.Product)
                .ToListAsync();
            return orderItems;
        }
    }
}
