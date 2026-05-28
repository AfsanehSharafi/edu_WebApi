using Domain.Entities;

namespace Application.Contracts
{
    public interface ProductRepository:IGenericRepository<Product>
    {
        Task<IReadOnlyList<Product>> SearchByNameAsync(string name);

        Task<IReadOnlyList<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IReadOnlyList<Product>> GetActiveProductsAsync();
    }
}
