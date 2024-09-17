using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<CategoryEntitty> Categories {  get; set; }
        public DbSet<ArchiveCategoryEntity> ArchiveCategories { get; set; }
        public DbSet<ProductEntity> Products {  get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NIhat\\SQLEXPRESS;Database=ShopDb;Trusted_Connection=True;");
        }
    }
}
