using Domain.Common;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string  Description { get; set; }
        public string  Color { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntitty Category { get; set; }
    }
}
