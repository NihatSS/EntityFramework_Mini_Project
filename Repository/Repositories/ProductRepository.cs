using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Drawing;

namespace Repository.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ProductEntity> _products;
        public ProductRepository()
        {
            _context = new AppDbContext();
            _products = _context.Set<ProductEntity>();
        }

        public async Task<IEnumerable<ProductEntity>> FilterByCategoryNameAsync(string categoryName)
        {
            return await _products.Include(m => m.Category).Where(m => m.Category.Name == categoryName).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _products.ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllWithCategoryIdAsync()
        {
            return await _products.Include(m => m.Category).ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _products.FindAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> SearchByColorAsync(string color)
        {
            return await _products.Where(m => m.Color == color).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> SearchByNameAsync(string name)
        {
            return await _products.Where(m => m.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> SortByCreatedDateAsync()
        {
            return await _products.OrderBy(m => m.CreatedDate).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> SortWithPriceAsync()
        {
            return await _products.OrderBy(m => m.Price).ToListAsync();
        }
    }
}
