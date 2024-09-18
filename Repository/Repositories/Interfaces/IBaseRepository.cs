using Domain.Common;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
