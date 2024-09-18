using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntitty>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<CategoryEntitty> _categories;
        public CategoryRepository()
        {
            _context = new();
            _categories = _context.Set<CategoryEntitty>();
        }


        public async Task<IEnumerable<CategoryEntitty>> SearchAsync(string searchText)
        {
            return await _categories.Where(m => m.Name == searchText).ToListAsync();
        }

        public async Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync()
        {
            return await _categories.Include(m => m.Products).ToListAsync();
        }

        public async Task<IEnumerable<CategoryEntitty>> GetArchiveCategoriesAsync()
        {
            return await _categories.ToListAsync();
        }



        public async Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync()
        {
            return await _categories.OrderBy(m => m.CreatedDate).ToListAsync();
        }
    }
}
