using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<UserEntity> _users;
        public UserRepository()
        {
            _context = new AppDbContext();
            _users = _context.Set<UserEntity>();
        }
        public async Task Check(string username, string password)
        {
            await _users.FindAsync(username, password);
        }
    }
}
