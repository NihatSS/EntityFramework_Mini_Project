using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Entity_Framework_Mini_Project.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;

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
            CategoryName: string categoryName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                Console.WriteLine(ErrorMessages.WrongInput);
                goto CategoryName;
            }

            _service.CreateAsync(new CategoryEntitty { Name = categoryName });
            ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
        }


        //Heleki islemir 
        public async Task Delete()
        {
            Console.WriteLine(AskMessages.AskCategoryId);
            Id: string categoryId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(categoryId, out int id);
            if (isCorrectFormat)
            {
                await _service.DeleteAsync(id);
                ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
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
                ConsoleColor.Cyan.WriteConsole($"Category: {category.Name}\n");
            }
        }

        public async Task GetById()
        {
            Console.WriteLine(AskMessages.AskCategoryId);
            Id: string strId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strId, out int id);
            if (isCorrectFormat)
            {
                var category = await _service.GetByIdAsync(id);
                ConsoleColor.Cyan.WriteConsole($"Category: {category.Name}");
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
                ConsoleColor.Cyan.WriteConsole($"Category: {category.Name} \nProducts: {category.Products}");
            }
        }

        public async Task SortWithCreatedDateAsync()
        {
            var catedories = await _service.SortWithCreatedDateAsync();
            foreach (var category in catedories)
            {
                ConsoleColor.Cyan.WriteConsole($"Category: {category.Name}");
            }

        }


    }
}
