using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface ICategoryService : IBaseService<CategoryEntitty>
    {
        Task<IEnumerable<CategoryEntitty>> GetAllAsync();
        Task<CategoryEntitty> GetByIdAsync(int id);
        Task<IEnumerable<CategoryEntitty>> SearchAsync(string searchText);
        Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync();
        Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync(int operation);
        Task<IEnumerable<ArchiveCategoryEntity>> GetArchiveCategoriesAsync();
    }
}
