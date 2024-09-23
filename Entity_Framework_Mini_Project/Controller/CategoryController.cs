using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Entity_Framework_Mini_Project.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;
using System.Text.RegularExpressions;

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
            string symbols = @"^[\p{L}\p{M}' \.\-]+$";
            Console.WriteLine(AskMessages.AskCategoryName);
            CategoryName: string categoryName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(categoryName) || !Regex.IsMatch(categoryName,symbols) || !categoryName.Any(char.IsLetterOrDigit))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryName;
            }
            for (int i = 1; i < categoryName.Length; i++)
            {
                if (categoryName[i].ToString() != categoryName[i].ToString().ToLower())
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    goto CategoryName;
                }
            }
            var categories = _service.GetAllAsync();
            foreach (var category in await categories)
            {
                if (category.Name.ToLower().Trim() == categoryName.ToLower()) 
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.CategoryAlreadyExist);
                    goto CategoryName;
                }
            }


            _service.CreateAsync(new CategoryEntitty { Name = categoryName });
            ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
        }


        public async Task Delete()
        {
            GetAll();
            Console.WriteLine(AskMessages.AskCategoryId);

            string categoryId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(categoryId, out int id);

            if (isCorrectFormat)
            {
                ConsoleColor.DarkYellow.WriteConsole(AskMessages.AskPermissionToDelete);

                string permission = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(permission))
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    return;
                }

                try
                {
                    switch (permission.ToLower())
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
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.NoData);
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
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
            string symbols = @"^[\p{L}\p{M}' \.\-]+$";
            GetAll();
            var categories = await _service.GetAllAsync();
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskCategoryId);
            Id: string strId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strId, out int id);
            if (isCorrectFormat)
            {
                var oldCategory = await _service.GetByIdAsync(id);
                if (oldCategory == null)
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.NoData + " Please try again:");
                    goto Id;
                }
                ConsoleColor.Yellow.WriteConsole(AskMessages.AskCategoryName);
                Name: string categoryName = Console.ReadLine().Trim();

                foreach (var category in categories)
                {
                    if (category.Name == categoryName)
                    {
                        ConsoleColor.Red.WriteConsole(ErrorMessages.CategoryAlreadyExist);
                        goto Name;
                    }
                }
                if (!Regex.IsMatch(categoryName, symbols) || !categoryName.Any(char.IsLetterOrDigit))
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    goto Name;
                }

                _service.UpdateAsync(id, new CategoryEntitty { Name = categoryName });
                ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessFullUpdate);
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Id;
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
                    ConsoleColor.Red.WriteConsole(ErrorMessages.NoData + " Please try again:");
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
            if (string.IsNullOrWhiteSpace(searchText) || !searchText.Any(char.IsLetter) || searchText.Any(char.IsDigit))
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
                ConsoleColor.Cyan.WriteConsole($"{category.Id}. Category: {category.Name}\nProducts:\n---------------------------------------");
                foreach (var product in category.Products)
                {
                    ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} | Price: {product.Price}  | Count: {product.Count} | Color: {product.Color}\n----------------------------------------------------------");
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

        public async Task GetArchiveCategories()
        {
            var categories = await _service.GetArchiveCategoriesAsync();
            foreach (var category in categories)
            {
                ConsoleColor.Cyan.WriteConsole($"Category: {category.Name} | Deleted date: {category.CreatedDate}");
            }
        }

        
    }
}
