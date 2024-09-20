using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
    }
}
