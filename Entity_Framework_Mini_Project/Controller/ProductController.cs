using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Constants;
using Entity_Framework_Mini_Project.Helper.Extentions;
using Entity_Framework_Mini_Project.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;

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
            foreach (var product in await _service.GetAllAsync())
            {
                ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} Count: {product.Count} Price: {product.Price} Color: {product.Color} Description: {product.Description}\n--------------------------------------------------");
            }
        }


        public async Task Create()
        {
            var products = await _service.GetAllAsync();
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductName);
            ProductName: string productName = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(productName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto ProductName;
            }
            foreach (var product in products)
            {
                if (product.Name.ToLower().Trim() == productName.ToLower())
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.ProductAlreadyExist);
                    goto ProductName;
                }
            }
            for (int i = 1; i < productName.Length; i++)
            {
                if (productName[i].ToString() != productName[i].ToString().ToLower())
                {
                    ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                    goto ProductName;
                }
            }

            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductPrice);
            Price: string strPrice = Console.ReadLine();
            bool isCorrectPriceFormat = decimal.TryParse(strPrice, out decimal price);
            if (isCorrectPriceFormat == false)
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Price;
            }

            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductCount);
            string strCount = Console.ReadLine();
            bool isCorrectCountFormat = int.TryParse(strPrice, out int count);
            if (isCorrectCountFormat == false)
            {
                count = 0;
            }

            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductColor);
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

            ConsoleColor.Yellow.WriteConsole($"Enter the {productName}'s description:");
            string description = Console.ReadLine();

            ConsoleColor.Yellow.WriteConsole(AskMessages.AskCategoryId);
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

        public async Task Delete()
        {
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductId);
            CategoryId: string strId = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strId, out int categoryId);
            if (isCorrectFormat)
            {
                _service.DeleteAsync(categoryId);
                ConsoleColor.Green.WriteConsole(SuccessfullMessages.SuccessfullOperation);
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryId;
            }
        }


        public async Task FilterByCategoryName()
        {
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskCategoryName);
            CategoryName: string categoryName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto CategoryName;
            }
            var categories = await _service.FilterByCategoryNameAsync(categoryName.ToLower());
            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    ConsoleColor.Cyan.WriteConsole($"Products:\nName: {product.Name} | Price: {product.Price} | Count: {product.Count} | Color: {product.Color} | Description: {product.Description}");
                }
            }
        }

        public async Task GetAllWithCategoryId()
        {
            var products = await _service.GetAllWithCategoryIdAsync();
            foreach (var product in products)
            {
                ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} || Price: {product.Price} || Count:  {product.Count} || Color: {product.Color} || Description: {product.Description} || CategoryId:{product.CategoryId}");
            }
        }

        public async Task GetById()
        {
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductId);
            Id: string strId = Console.ReadLine();
            bool idCorrectFormat = int.TryParse(strId,out int id);
            if (idCorrectFormat)
            {
                var product = await _service.GetByIdAsync(id);
                ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} || Price: {product.Price} || Count:  {product.Count} || Color: {product.Color} || Description: {product.Description}");
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ErrorMessages.WrongInput);
                goto Id;
            }
        }


        public async Task SearchByColor()
        {
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductColor);
            Color: string color = Console.ReadLine();
            var products = _service.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(color))
            {
                for (int i = 0; i < color.Length; i++)
                {
                    if (int.TryParse(color[i].ToString(), out int n))
                    {
                        ConsoleColor.Red.WriteConsole(ErrorMessages.WrongColorInpuWithNumber);
                        goto Color;
                    }
                }
                products = _service.SearchByColorAsync(color);
            }
            foreach (var product in await products)
            {
                ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} || Price: {product.Price} || Count:  {product.Count} || Color: {product.Color} || Description: {product.Description}");
            }
        }

       public async Task SearchByName()
        {
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductName);
            string name = Console.ReadLine();
            var products = _service.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(name))
            {
                products = _service.SearchByNameAsync(name);
            }
            foreach (var product in await products)
            {
                ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} || Price: {product.Price} || Count:  {product.Count} || Color: {product.Color} || Description: {product.Description}");
            }
        }

        public async Task SortByCreateDate()
        {
            ConsoleColor.Yellow.WriteConsole("1-Order by increasing\n2-Order by decreasing");
            Operation: string strOperation = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strOperation, out var operation);
            if (isCorrectFormat)
            {
                if (operation == 1 || operation == 2)
                {
                    var products = _service.SortByCreatedDateAsync(operation);
                    foreach (var product in await products)
                    {
                        ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} || Price: {product.Price} || Count:  {product.Count} || Color: {product.Color} || Description: {product.Description}");
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
        public async Task SortWithPrice()
        {
            ConsoleColor.Yellow.WriteConsole("1-Order by increasing\n2-Order by decreasing");
            Operation: string strOperation = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strOperation, out var operation);
            if (isCorrectFormat)
            {
                if (operation == 1 || operation == 2)
                {
                    var products = _service.SortWithPriceAsync(operation);
                    foreach (var product in await products)
                    {
                        ConsoleColor.Cyan.WriteConsole($"Name: {product.Name} || Price: {product.Price} || Count:  {product.Count} || Color: {product.Color} || Description: {product.Description}");
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

        public async Task Update()
        {
            ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductId);
            string strId = Console.ReadLine();
            bool isCorrectIdFormat = int.TryParse(strId, out int id);
            if (isCorrectIdFormat)
            {
                var oldProduct = await _service.GetByIdAsync(id);

                ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductName);
                string productName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(productName))
                {
                    productName = oldProduct.Name;
                }

                ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductPrice);
                string strPrice = Console.ReadLine();
                bool isCorrectPriceFormat = decimal.TryParse(strPrice, out decimal price);
                if (isCorrectPriceFormat == false || string.IsNullOrWhiteSpace(strPrice))
                {
                    price = oldProduct.Price;
                }
                
                ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductCount);
                string strCount = Console.ReadLine();
                bool isCorrectCountFormat = int.TryParse(strPrice, out int count);
                if (isCorrectPriceFormat == false || string.IsNullOrWhiteSpace(strPrice))
                {
                    count = oldProduct.Count;
                }

                ConsoleColor.Yellow.WriteConsole(AskMessages.AskProductColor);
                string color = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(color))
                {
                    color = oldProduct.Color;
                }

                await _service.UpdateAsync(id, new ProductEntity { Name = productName, Price = price, Count = count, Color = color });
            }
        }
    }
}
