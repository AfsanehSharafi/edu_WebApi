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
            return await _context.Orders
                .AsNoTracking()
                .Where(o=> o.UserId == userId)
                .OrderByDescending(o=> o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderWithDetailAsync(int orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(o=> o.OrderItems)
                .ThenInclude(oi=> oi.Product)
                .Include(o=> o.User)
                .FirstOrDefaultAsync(o=> o.Id == orderId);
        }

        public async Task UpdateStatusAsync(int orderId, OrderStatus status)
        {
                await _context.Orders
                .Where(o=> o.Id ==orderId)
                .ExecuteUpdateAsync(setter=> setter.SetProperty(o=> o.Status, status));
        }
    }
}
