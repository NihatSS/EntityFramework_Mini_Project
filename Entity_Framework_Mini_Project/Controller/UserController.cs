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

        public async Task Create()
        {
            FullName: Console.WriteLine("Enter the user's fullname:");
            string fullName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto FullName;
            }

            Console.WriteLine("Enter the username:");
            UserName: string userName  = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto UserName;
            }

            Console.WriteLine("Enter the password (Mininum 1 uppercase,1 number):");
            Password: string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Password;
            }

            for (int i = 0; i < password.Length; i++)
            {
                if (Convert.ToInt32(password[i]) != null && password[i].ToString() != password[i].ToString().ToLower())
                {
                    await _userService.CreateAsync(new UserEntity { FullName = fullName, UserName = userName, Password = password });
                    ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WeakPassword);
                    goto Password;
                }
            }
        }


        public async Task Delete()
        {
            Console.WriteLine("Enter the user's id:");
            Id: string strNum = Console.ReadLine();

            bool isCorretFormat = int.TryParse(strNum,out int id);
            if (isCorretFormat)
            {
                await _userService.DeleteAsync(id);
                ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Id;
            }
        }

        public async Task 
    }
}
