using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userService;
        public UserService()
        {
            _userService = new UserRepository();
        }
        public async Task Check(string userName, string password)
        {
            await _userService.Check(userName, password);
        }

        public async Task CreateAsync(UserEntity entity)
        {
             await _userService.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, UserEntity entity)
        {
            await _userService.UpdateAsync(id, entity);
        }
    }
}
