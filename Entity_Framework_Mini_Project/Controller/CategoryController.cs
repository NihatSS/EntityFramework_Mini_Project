using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Service.Services;
using Service.Services.Interfaces;
using System.Globalization;

namespace Entity_Framework_Mini_Project.Controller
{
    public class CategoryController
    {
        private readonly ICategoryService _repository;
        public CategoryController()
        {
            _repository = new CategoryService();
        }

        public async Task Create()
        {
            Console.WriteLine("Enter category name:");
            CategoryName: string categoryName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                Console.WriteLine(ErrorMessages.WrongInput);
                goto CategoryName;
            }

            _repository.CreateAsync(new CategoryEntitty { Name = categoryName });
        }

        public async Task GetAll()
        {
            foreach (var category in await _repository.GetAll())
            {
                Console.WriteLine($"Name: {category.Name}");
            }
        }

        public async Task<CategoryEntitty> GetById()
        {
            Console.WriteLine("Enter category id:");
            Id: string strId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strId, out int id);
            if (isCorrectFormat)
            {
                return await _repository.GetByIdAsync(id);
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

            var categories = await _repository.SearchAsync(searchText);
            foreach (var category in categories)
            {
                Console.WriteLine($"Name: {category.Name}");
            }
        }
        

        public async Task GetAllWithProducts()
        {
            var categories = await _repository.GetAllWithProductsAsync();
            foreach (var category in categories)
            {
                Console.WriteLine($"Category: {category.Name} \nProducts: {category.Products}");
            }
        }



    }
}
