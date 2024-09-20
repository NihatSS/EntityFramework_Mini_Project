using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
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

        public async Task Register()
        {
            FullName: ConsoleColor.Cyan.WriteConsole("Enter the user's fullname:");
            string fullName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto FullName;
            } if (fullName.Any(char.IsDigit))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto FullName;
            }
             if (!fullName.Any(char.IsLetterOrDigit))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto FullName;
            }

            ConsoleColor.Cyan.WriteConsole("Enter the username:");
            UserName: string userName  = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto UserName;
            }

            ConsoleColor.Cyan.WriteConsole("Enter the password (Mininum 8 caracters, 1 uppercase,1 number):");
            Password: string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password) && password.Length >8 )
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Password;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (Convert.ToInt32(password[i]) != null && password[i].ToString() != password[i].ToString().ToLower() && password.Length >= 8)
                {
                    break;
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WeakPassword);
                    goto Password;
                }
            }

            ConsoleColor.Cyan.WriteConsole("Enter the email:");
            Email: string email = Console.ReadLine();



            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Email;
            }if (!email.Contains('@') || !email.Contains('.'))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongEmailInput);
                goto Email;
            }

            _userService.CreateAsync(new UserEntity { FullName = fullName, UserName = userName, Password = password, Email = email });
            ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullRegister);

        }

        public async Task Login()
        {
            ConsoleColor.Cyan.WriteConsole("Enter the username:");
            UserName: string userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto UserName;
            }

            ConsoleColor.Cyan.WriteConsole("Enter the password (Mininum 1 uppercase,1 number):");
            Password: string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Password;
            }

            await _userService.Check(userName, password);
            ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccesfullLogin);
        }

    }
}
