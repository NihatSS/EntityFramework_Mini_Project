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
            var data = _categories.Where(m => m.Name.Contains(searchText)).ToList();
            return data;
        }

        public async Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync()
        {
            return await _categories.Include(m => m.Products).ToListAsync();
        }

        public async Task<IEnumerable<CategoryEntitty>> GetArchiveCategoriesAsync()
        {
            return await _categories.ToListAsync();
        }



        public async Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync(int operation)
        {
            if (operation == 1)
            {
                return  _categories.OrderBy(m => m.CreatedDate).ToList();
            }
            else
            {
                return _categories.OrderByDescending(m => m.CreatedDate).ToList();
            }
        }
    }
}
