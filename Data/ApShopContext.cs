using System.Data;
using Microsoft.EntityFrameworkCore;
using apshop.Data.Models;

namespace apshop.Data
{
    public class ApShopContext : DbContext
    {
        public ApShopContext(DbContextOptions<ApShopContext> options) : base(options) {
        }

        public DbSet<Item> items { get; set; }
        public DbSet<Category> categories { get; set; }
        public  DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
       
     

    } 
}
