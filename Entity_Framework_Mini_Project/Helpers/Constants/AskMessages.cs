using System.Globalization;

namespace Entity_Framework_Mini_Project.Helpers.Constants
{
    public class AskMessages
    {
        public const string AskCategoryId = "Enter id:";
        public const string AskProductId = "Enter id:";
        public const string AskCategoryName = "Enter category's name:";
        public const string AskProductName = "Enter product's name:";
        public const string AskProductPrice = "Enter product's price";
        public const string AskProductCount = "Enter product's count:";
        public const string AskProductColor = "Enter product's color:";
        public const string AskProduct = "Enter product's count:";
        public const string AskCategoryMethods = "Category operation:\n1-GetAll\n2-Create\n3-Delete\n4-Update\n5-GetById\n6-Search\n7-GetAllWithProducts\n8-SortWithCreatedDate\n9-GetArchiveCategory\n10-Back";
        public const string AskProductMethods = "Product methods:\n1-GetAll\n2-Create\n3-Delete\n4-Update\n5-GetById\n6-GetAllByCategoryId\n7-FilterByCategoryName\n8-SearchByColor\n9-SearchByName\n10-SortByCreateDate\n11-SortByPrice\n12-Back";
        public const string AskPermissionToDelete = "Are you sure to delete!y/n";
    }
}
