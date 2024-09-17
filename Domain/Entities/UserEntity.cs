using Domain.Common;
using System.Globalization;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
