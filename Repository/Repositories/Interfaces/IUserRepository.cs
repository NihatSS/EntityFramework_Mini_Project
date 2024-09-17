using Domain.Common;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task Check(string username, string password);
    }
}
