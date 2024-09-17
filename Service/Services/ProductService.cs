﻿using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ProductService : BaseService<ProductEntity>, IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService()
        {
            _repository = new ProductRepository();
        }
        public async Task<IEnumerable<ProductEntity>> FilterByCategoryName(string categoryName)
        {
            return await _repository.FilterByCategoryNameAsync(categoryName);
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllWithCategoryId()
        {
            return await _repository.GetAllWithCategoryIdAsync();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> SearchByColor(string color)
        {
            return await _repository.SearchByColorAsync(color);
        }

        public async Task<IEnumerable<ProductEntity>> SearchByName(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }

        public async Task<IEnumerable<ProductEntity>> SortByCreatedDate()
        {
            return await _repository.SortByCreatedDateAsync();
        }

        public async Task<IEnumerable<ProductEntity>> SortWithPrice()
        {
            return await _repository.SortWithPriceAsync();
        }
    }
}
