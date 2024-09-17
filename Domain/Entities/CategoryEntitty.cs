using Domain.Common;

namespace Domain.Entities
{
    public class CategoryEntitty : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
