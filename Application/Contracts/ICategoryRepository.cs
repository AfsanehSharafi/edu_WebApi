using Domain.Entities;

namespace Application.Contracts
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {

        Task<bool> ExistsByNameAsync(string name);
    }
}
