using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface ICategoryService : IBaseService<CategoryEntitty>
    {
        Task<IEnumerable<CategoryEntitty>> GetAll();
        Task<CategoryEntitty> GetByIdAsync(int id);
        Task<IEnumerable<CategoryEntitty>> SearchAsync(string searchText);
        Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync();
        Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync();
        Task<IEnumerable<CategoryEntitty>> GetArchiveCategoriesAsync();
    }
}
