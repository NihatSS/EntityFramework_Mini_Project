using Domain.Entities;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
    }
}
