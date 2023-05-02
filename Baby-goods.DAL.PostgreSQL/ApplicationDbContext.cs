using Baby_goods.DAL.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Baby_goods.DAL.PostgreSQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<OrderItemEntity> OrderItem { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<ShoppingCartItemEntity> ShoppingCartItem { get; set; }
        public DbSet<UserEntity> User  { get; set; }
    }
}
