using Domain.Common;

namespace Service.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task<IEnumerable<T>> GetAllAsync();

    }
}
