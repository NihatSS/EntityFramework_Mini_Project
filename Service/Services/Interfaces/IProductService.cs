using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface IProductService : IBaseService<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAll();
        Task<ProductEntity> GetById(int id);
        Task<IEnumerable<ProductEntity>> SearchByName(string name);
        Task<IEnumerable<ProductEntity>> FilterByCategoryName(string categoryName);
        Task<IEnumerable<ProductEntity>> GetAllWithCategoryId();
        Task<IEnumerable<ProductEntity>> SortWithPrice();
        Task<IEnumerable<ProductEntity>> SortByCreatedDate();
        Task<IEnumerable<ProductEntity>> SearchByColor(string color);
    }
}
