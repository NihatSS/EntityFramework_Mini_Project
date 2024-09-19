﻿using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface IProductService : IBaseService<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetByIdAsync(int id);
        Task<IEnumerable<ProductEntity>> SearchByNameAsync(string name);
        Task<IEnumerable<ProductEntity>> FilterByCategoryNameAsync(string categoryName);
        Task<IEnumerable<ProductEntity>> GetAllWithCategoryIdAsync();
        Task<IEnumerable<ProductEntity>> SortWithPriceAsync();
        Task<IEnumerable<ProductEntity>> SortByCreatedDateAsync(int operation);
        Task<IEnumerable<ProductEntity>> SearchByColorAsync(string color);
    }
}
