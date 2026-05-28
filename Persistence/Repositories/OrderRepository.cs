using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataBaseContext _context;

        public OrderRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Order>> GetOrderByUserIdAsync(int userId)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o=> o.UserId == userId)
                .Include(o=> o.OrderItems)
                .ToListAsync();
            return orders;
        }

        public async Task<Order?> GetOrderWithDetailAsync(int orderId)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .Include(o=> o.OrderItems)
                .ThenInclude(oi=> oi.Product)
                .Include(o=> o.User)
                .FirstOrDefaultAsync(o=> o.Id == orderId);
            return order;
        }

        public async Task UpdateStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);
                if(order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
