using Microsoft.EntityFrameworkCore;

namespace FoodPandaIdentity.Models
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<PlacedOrders> PlacedOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoodPandaIdentity;Integrated Security=True");
        }
    }
}
