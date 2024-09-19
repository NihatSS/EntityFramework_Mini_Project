using Domain.Common;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<CategoryEntitty>
    {
        Task<IEnumerable<CategoryEntitty>> SearchAsync(string searchText);
        Task<IEnumerable<CategoryEntitty>> GetAllWithProductsAsync();
        Task<IEnumerable<CategoryEntitty>> SortWithCreatedDateAsync(int operation);
    }
}
