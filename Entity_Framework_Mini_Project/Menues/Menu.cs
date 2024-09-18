using Entity_Framework_Mini_Project.Controller;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;

namespace Entity_Framework_Mini_Project.Menues
{
    public class Menu
    {
        public Menu()
        {
            UserController userController = new UserController();
            CategoryController categoryController = new CategoryController();
            ProductController productController = new ProductController();
            do
            {
                //bool isTrueAuthenticationFinised = true;
                //while (isTrueAuthenticationFinised)
                //{
                //    ConsoleColor.Yellow.WriteConsole("Enter the operation!\n1-Login\n2-Register\n3-Delete user");
                //    Authentication: string strNum = Console.ReadLine();

                //    bool isCorrectFormat = int.TryParse(strNum, out int operation);
                //    if (isCorrectFormat)
                //    {
                //        switch (operation)
                //        {
                //            case 1:
                //                userController.Login();
                //                isTrueAuthenticationFinised = false;
                //                break;
                //            case 2:
                //                userController.Register();
                //                isTrueAuthenticationFinised = false;
                //                break;
                //            case 3:
                //                userController.Delete();
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine(ErrorMessages.WrongInput);

                //        goto Authentication;
                //    }

                //}



            } while (true);
        }
    }
}
