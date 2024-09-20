using Entity_Framework_Mini_Project.Controller;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Entity_Framework_Mini_Project.Helpers.Constants;
using Entity_Framework_Mini_Project.Helpers.Operations;
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
                    bool isTrueAuthenticationFinised = true;
                    while (isTrueAuthenticationFinised)
                    {
                        ConsoleColor.Yellow.WriteConsole("Enter the operation!\n1-Login\n2-Register");
                        Authentication: string strNum = Console.ReadLine();

                        bool isCorrectFormat = int.TryParse(strNum, out int operation);
                        if (isCorrectFormat)
                        {
                            switch (operation)
                            {
                                case (int)UserOperations.Login:
                                    userController.Login();
                                    isTrueAuthenticationFinised = false;
                                    break;
                                case (int)UserOperations.Register:
                                    userController.Register();
                                    isTrueAuthenticationFinised = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(ErrorMessages.WrongInput);

                            goto Authentication;
                        }
                    }


                    Methods: ConsoleColor.Yellow.WriteConsole("1-Get categry methods\n2-Get product methods");
                    string strOperation = Console.ReadLine();
                    bool isCorretOperationFormat = int.TryParse(strOperation, out int opr);
                    if (isCorretOperationFormat)
                    {
                        do
                        {
                            switch (opr)
                            {
                                case (int)Methods.Category:
                                    ConsoleColor.DarkYellow.WriteConsole(AskMessages.AskCategoryMethods);
                                    CategoryName: string strCategoryMethod = Console.ReadLine();
                                    bool isCorrectCategoryMethodFormat = int.TryParse(strCategoryMethod, out int categoryMethod);
                                    if (isCorrectCategoryMethodFormat)
                                    {
                                        switch (categoryMethod)
                                        {
                                            case (int)CategoryMethods.GetAll:
                                                categoryController.GetAll();
                                                break;
                                            case (int)CategoryMethods.Create:
                                                categoryController.Create(); 
                                                break;
                                            case (int)CategoryMethods.Delete:
                                                categoryController.Delete();
                                                break;
                                            case (int)CategoryMethods.Update: 
                                                categoryController.Update();
                                                break;
                                            case (int)CategoryMethods.GetById:
                                                categoryController.GetById();
                                                break;
                                            case (int)CategoryMethods.Search:
                                                categoryController.Search();
                                                break;
                                            case (int)CategoryMethods.GetAllWithProducts:
                                                categoryController.GetAllWithProducts();
                                                break;
                                            case (int)CategoryMethods.SortWithCreatedDate:
                                                categoryController.SortWithCreatedDate();
                                                break;
                                            case (int)CategoryMethods.Back:
                                                Console.Clear();
                                                goto Methods;
                                            default:
                                                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                                                goto CategoryName;
                                        }
                                    }
                                    break;
                                case (int)Methods.Product: 
                                    ConsoleColor.DarkYellow.WriteConsole(AskMessages.AskProductMethods);
                                    ProductMethod: string strProductMethod = Console.ReadLine();
                                    bool isCorrectProductMethodFormat = int.TryParse(strProductMethod, out int productMethod);
                                    if (isCorrectProductMethodFormat)
                                    {
                                        switch (productMethod)
                                        {
                                            case (int)ProductMethods.GetAll:
                                                productController.GetAll();
                                                break;
                                            case (int)ProductMethods.Create:
                                                productController.Create(); 
                                                break;
                                            case (int)ProductMethods.Delete:
                                                productController.Delete();
                                                break;
                                            case (int)ProductMethods.GetById:
                                                productController.GetById();
                                                break;
                                            case (int)ProductMethods.GetAllWithCategoryId:
                                                productController.GetAllWithCategoryId();
                                                break;
                                            case (int)ProductMethods.FilterByCategoryName:
                                                productController.FilterByCategoryName();
                                                break;
                                            case (int)ProductMethods.SearchByColor:
                                                productController.SearchByColor();
                                                break;
                                            case (int)ProductMethods.SearchByName:
                                                productController.SearchByName();
                                                break;
                                            case (int)ProductMethods.SortByCreateDate:
                                                productController.SortByCreateDate();
                                                break;
                                            case (int)ProductMethods.SortWithPrice:
                                                productController.SortWithPrice();
                                                break;
                                            case (int)ProductMethods.Back:
                                                goto Methods;
                                            default:
                                                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                                                goto ProductMethod;
                                        }
                                    }

                                    break;
                                default:
                                    break;
                            }

                        } while (true);
                    
                }

                } while (true);


            }
        }
    }

