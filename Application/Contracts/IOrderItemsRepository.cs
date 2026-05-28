using Domain.Entities;

namespace Application.Contracts
{
    public interface IOrderItemsRepository:IGenericRepository<OrderItems>
    {
        Task<IReadOnlyList<OrderItems>> GetItemsByOrderIdAsync(int orderId);
        Task<bool> ExistsInOrderAsync(int orderId, int productId);
    }
}
