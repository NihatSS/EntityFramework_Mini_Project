using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class UserService : BaseService<UserEntity>, IUserService
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
    }
}
