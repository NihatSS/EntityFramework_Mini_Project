using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Service.Services;
using Service.Services.Interfaces;
using System.Threading.Channels;

namespace Entity_Framework_Mini_Project.Controller
{
    public class ProductController
    {
        private readonly IProductService _service;

        public ProductController()
        {
            _service = new ProductService();
        }

        public async Task GetAll()
        {
            foreach (var product in await _service.GetAll())
            {
                 Console.WriteLine($"Name: {product.Name} Count: {product.Count} Price: {product.Price} Color: {product.Color} Description: {product.Description}\n--------------------------------------------------");
            }
        }


        //Heleki islemir
        public async Task Create()
        {
            Console.WriteLine("Enter the product name:");
            ProductName: string productName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(productName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto ProductName;
            }

            Console.WriteLine("Enter the product price:");
            Price: string strPrice = Console.ReadLine();
            bool isCorrectPriceFormat = decimal.TryParse(strPrice, out decimal price);
            if (isCorrectPriceFormat == false)
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Price;
            }

            Console.WriteLine("Enter the products count:");
            string strCount = Console.ReadLine();
            bool isCorrectCountFormat = int.TryParse(strPrice, out int count);
            if (isCorrectCountFormat == false)
            {
                count = 0;
            }

            Console.WriteLine("Enter the product color:");
            Color: string color = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(color))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Color;
            }
            for(int i = 0; i < color.Length; i++)
            {
                if (int.TryParse(color[i].ToString(),out int n))
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongColorInpuWithNumber);
                    goto Color;
                }
            }

            Console.WriteLine($"Enter the {productName}'s description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter category id:");
            CategoryId: string strCategoryId = Console.ReadLine();
            bool isCorrectIdFormat = int.TryParse(strCategoryId, out int categoryId);
            if (isCorrectIdFormat == false)
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryId;
            }

            await _service.CreateAsync(new ProductEntity { Name = productName, Count = count, Description = description , Price = price , Color = color, CategoryId = categoryId });
            ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullCreatedData);
        }
    }
}
