using Domain.Common;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductEntity> 
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetByIdAsync(int id);
        Task<IEnumerable<ProductEntity>> SearchByNameAsync(string name);
        Task<IEnumerable<ProductEntity>> FilterByCategoryNameAsync(string categoryName);
        Task<IEnumerable<ProductEntity>> GetAllWithCategoryIdAsync();
        Task<IEnumerable<ProductEntity>> SortWithPriceAsync();
        Task<IEnumerable<ProductEntity>> SortByCreatedDateAsync();
        Task<IEnumerable<ProductEntity>> SearchByColorAsync(string color);

    }
}
