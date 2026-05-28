using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, Application.Contracts.ProductRepository
    {
        private readonly DataBaseContext _context;
        public ProductRepository(DataBaseContext context): base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetActiveProductsAsync()
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p=> p.IsActive)
                .Include(p=> p.Category)
                .ToListAsync();
            return products;
        }

        public async Task<IReadOnlyList<Product>> GetByCategoryIdAsync(int categoryId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId & p.IsActive)
                .Include(p => p.Category)
                .ToListAsync();
            return products;
        }

        public async Task<IReadOnlyList<Product>> SearchByNameAsync(string name)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(p=> p.Name.Contains(name) & p.IsActive )
                .Include(p=> p.Category)
                .ToListAsync();
            return products;
        }
    }
}
