using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBaseContext _context;

        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Categories
                .Where(c=> c.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c=> c.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Categories.AnyAsync(c=> c.Name == name);
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
