using Domain.Entities;

namespace Application.Contracts
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> IsUsernameTakenAsync(string username);
    }
}
