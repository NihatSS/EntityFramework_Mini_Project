using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Exceptions;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public async Task CreateAsync(ProductEntity entity)
        {
            await _repository.CreateAsync(entity);
        }
        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(int id, ProductEntity product)
        {
            var existCategory = await _repository.GetByIdAsync(id) ?? throw new NotFoundException("Data not found");

            if (string.IsNullOrEmpty(product.Name.Trim()))
            {
                product.Name = existCategory.Name;
                product.Description = existCategory.Description;
                product.Color = existCategory.Color;
                await _repository.UpdateAsync(existCategory);
            }
            else
            {
                existCategory.Name = product.Name;
                existCategory.Description = product.Description;
                existCategory.Color = product.Color;
                await _repository.UpdateAsync(existCategory);
            }
        }

        public async Task<IEnumerable<CategoryEntitty>> FilterByCategoryNameAsync(string categoryName)
        {
            return await _repository.FilterByCategoryNameAsync(categoryName);
        }


        public async Task<IEnumerable<ProductEntity>> GetAllWithCategoryIdAsync()
        {
            return await _repository.GetAllWithCategoryIdAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> SearchByColorAsync(string color)
        {
            return await _repository.SearchByColorAsync(color);
        }

        public async Task<IEnumerable<ProductEntity>> SearchByNameAsync(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }

        public async Task<IEnumerable<ProductEntity>> SortByCreatedDateAsync(int operation)
        {
            return await _repository.SortByCreatedDateAsync(operation);
        }

        public async Task<IEnumerable<ProductEntity>> SortWithPriceAsync(int operation)
        {
            return await _repository.SortWithPriceAsync(operation);
        }

       
    }
}
