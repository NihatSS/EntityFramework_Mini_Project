using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Entity_Framework_Mini_Project.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;
using System.Globalization;

namespace Entity_Framework_Mini_Project.Controller
{
    public class CategoryController
    {
        private readonly ICategoryService _service;
        public CategoryController()
        {
            _service = new CategoryService();
        }

        public async Task Create()
        {
            Console.WriteLine(AskMessages.AskCategoryName);
            CategoryName: string categoryName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryName;
            }else if (categoryName.Any(char.IsDigit))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryName;
            }else if (!categoryName.Any(char.IsLetterOrDigit))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryName;
            }
            var categories = _service.GetAllAsync();
            foreach (var category in await categories)
            {
                if (category.Name.ToLower() == categoryName.ToLower()) 
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    goto CategoryName;
                }
            }


            _service.CreateAsync(new CategoryEntitty { Name = categoryName });
            ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
        }


        public async Task Delete()
        {
            GetAll();
            Id: Console.WriteLine(AskMessages.AskCategoryId);
            string categoryId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(categoryId, out int id);
            if (isCorrectFormat)
            {
                ConsoleColor.DarkYellow.WriteConsole(AskMessages.AskPermissionToDelete);
                Permission: string permission = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(permission))
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    goto Permission;
                }
                switch (permission)
                {
                    case "y":
                        await _service.DeleteAsync(id);
                       ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
                        break;
                    case "n":
                        ConsoleColor.DarkGreen.WriteConsole("Delete canceled");
                        break;
                    default:
                        ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                        goto Permission;
                }
                
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Id;
            }
        }

        public async Task GetAll()
        {
            var categories = await _service.GetAllAsync();
            foreach (var category in categories)
            {
                ConsoleColor.Cyan.WriteConsole($"{category.Id}. Category: {category.Name}");
            }
        }


        public async Task Update()
        {
            GetAll();
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskCategoryId);
            string strId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strId, out int id);
            if (isCorrectFormat)
            {
                var oldUser = await _service.GetByIdAsync(id);
                ConsoleColor.Yellow.WriteConsole(AskMessages.AskCategoryName);
                Name: string categoryName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    _service.UpdateAsync(id, new CategoryEntitty { Name = oldUser.Name });
                    ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessFullUpdate);
                }
                _service.UpdateAsync(id, new CategoryEntitty { Name = categoryName });
                ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessFullUpdate);
            }
        }

        public async Task GetById()
        {
            Console.WriteLine(AskMessages.AskCategoryId);
            Id: string strId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strId, out int id);
            if (isCorrectFormat)
            {
                try
                {
                    var category = await _service.GetByIdAsync(id);
                    ConsoleColor.Cyan.WriteConsole($"Category: {category.Name}");
                }catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + ", Please try again:");
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Id;
            }

        }


        public async Task Search()
        {
            Console.WriteLine("Enter the text: ");
            Search: string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Search;
            }
            else if (searchText.Any(char.IsDigit))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Search;
            }
            else if (!searchText.Any(char.IsLetter))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Search;
            }

            var categories = await _service.SearchAsync(searchText);

            foreach (var category in categories)
            {
                ConsoleColor.Cyan.WriteConsole($"Name: {category.Name}");
            }
        }
        

        public async Task GetAllWithProducts()
        {
            foreach (var category in await _service.GetAllWithProductsAsync())
            {
                if (category.Products == null)
                {
                    ConsoleColor.Cyan.WriteConsole($"Category: {category.Name} \nProducts: no product");
                }
                else
                {
                    ConsoleColor.Cyan.WriteConsole($"Category: {category.Name} \nProducts: {category.Products}");
                }

            }
        }

        public async Task SortWithCreatedDate()
        {
            ConsoleColor.Yellow.WriteConsole("1-Order by increasing\n2-Order by decreasing");
            Operation: string strOperation = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strOperation, out var operation);
            if (isCorrectFormat)
            {
                if (operation == 1 || operation == 2)
                {
                    var catedories = await _service.SortWithCreatedDateAsync(operation);
                    foreach (var category in catedories)
                    {
                        ConsoleColor.Cyan.WriteConsole($"Category: {category.Name}");
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    goto Operation;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Operation;
            }
        }
    }
}
