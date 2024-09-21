using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System.Collections;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService()
        {
            _repository = new CategoryRepository();
        }

        public async Task<IEnumerable<CategoryEntitty>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task CreateAsync(CategoryEntitty entitty)
        {
            await _repository.CreateAsync(entitty);
        }

        public async Task<CategoryEntitty> GetByIdAsync(int id)
        {
            var data = _repository.GetByIdAsync(id);
            return await data;
        }

        public async Task<IEnumerable<CategoryEntitty>> SearchAsync(string searchText)
        {
            return await _repository.SearchAsync(searchText);
        }


        public async Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync()
        {
            return await _repository.GetAllWithProductsAsync();
        }

        public async Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync(int operation)
        {
            return await _repository.SortWithCreatedDateAsync(operation);
        }


        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, CategoryEntitty entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

        public async Task<IEnumerable<ArchiveCategoryEntity>> GetArchiveCategoriesAsync()
        {
            return await _repository.GetArchiveCategoriesAsync();
        }
    }
}
