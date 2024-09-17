using Entity_Framework_Mini_Project.Controller;
using Entity_Framework_Mini_Project.Helper.Constants;

namespace Entity_Framework_Mini_Project.Menues
{
    public class Menu
    {
        public Menu()
        {
            UserController userController = new UserController();
            do
            {
                Console.WriteLine("Enter the operation!\n1-Login\n2-Register\n3-Delete user");
                string strNum = Console.ReadLine();

                bool isCorrectFormat = int.TryParse(strNum, out int operation);
                if (isCorrectFormat)
                {
                    switch (operation)
                    {
                        case 1:
                            userController.Login();
                            break;
                        case 2:
                            userController.Register();
                            break;
                        case 3:
                            userController.Delete();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(ErrorMessages.WrongInput);
                }



            } while (true);
        }
    }
}
