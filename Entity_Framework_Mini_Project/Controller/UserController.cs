using Service.Services;
using Service.Services.Interfaces;

namespace Entity_Framework_Mini_Project.Controller
{
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public async Task Create()
        {
            FullName: Console.WriteLine("Enter the user's fullname:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter the username:");
            string userName  = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Please enter the username correctly!");
                goto FullName;
            }
            Console.WriteLine("Enter the password:");
            Password: string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Please enter the password correctly!");
                goto Password;
            }

            int passwordStrenght = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (Convert.ToInt32(password[i]) != null)
                {
                    passwordStrenght++;
                }
                if (password[i].ToString() != password[i].ToString().ToLower())
                {
                    passwordStrenght++;
                }
            }
        }
    }
}
