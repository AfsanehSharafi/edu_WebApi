using Domain.Entities;

namespace Application.Contracts
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<IReadOnlyList<Order>> GetOrderByUserIdAsync(int userId);
        Task<Order?> GetOrderWithDetailAsync(int orderId);
        Task UpdateStatusAsync(int orderId , OrderStatus status);
    }
}
