using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System.Collections;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _service;

        public CategoryService()
        {
            _service = new CategoryRepository();
        }

        public async Task<IEnumerable<CategoryEntitty>> GetAll()
        {
            return await _service.GetAll();
        }


        public async Task CreateAsync(CategoryEntitty entitty)
        {
            await _service.CreateAsync(entitty);
        }

        public async Task<CategoryEntitty> GetByIdAsync(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CategoryEntitty>> SearchAsync(string searchText)
        {
            return await _service.SearchAsync(searchText);
        }


        public async Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync()
        {
            return await _service.GetAllWithProductsAsync();
        }

        public async Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync()
        {
            return await _service.SortWithCreatedDateAsync();
        }

        public async Task<IEnumerable<CategoryEntitty>> GetArchiveCategoriesAsync()
        {
            return await _service.GetArchiveCategoriesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, CategoryEntitty entity)
        {
            await _service.UpdateAsync(id, entity);
        }
    }
}
